using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SearchEngine
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Structure to store index in dictionary and position in file of a word
        /// </summary>
        struct WordStruct
        {
            public int index, ln, col;
            public WordStruct(int Index, int Line, int Column)
            {
                index = Index;
                ln = Line;
                col = Column;
            }
        }

        /// <summary>
        /// List of all words in all files
        /// </summary>
        List<string> wordList = new List<string>();

        /// <summary>
        /// File indexes to store BitArrays of word occurrences for each file path
        /// </summary>
        Dictionary<string, BitArray> bitArrays = new Dictionary<string, BitArray>();

        /// <summary>
        /// File indexes to store collection (stack according to task) of WordStructs for each file path 
        /// </summary>
        Dictionary<string, Stack<WordStruct>> collections = new Dictionary<string, Stack<WordStruct>>();

        /// <summary>
        /// ReaderWriterLock to provide correct access to all collections between ScanAgent and search threads
        /// </summary>
        ReaderWriterLock locker = new ReaderWriterLock();

        /// <summary>
        /// AutoResetEvent to signal ScanAgent each time after user has selected new files to add
        /// </summary>
        AutoResetEvent scanAgentSignal = new AutoResetEvent(false);

        /// <summary>
        /// Queue to pass from user window thread to ScanAgent thread files that user has selected
        /// </summary>
        Queue<string> fileQueue = new Queue<string>();

        /// <summary>
        /// Comparer to compare two WordStructs based on their word indeces
        /// </summary>
        static WordComparer wordComparer = new WordComparer();

        /// <summary>
        /// Separator chars to split text into a set of words
        /// </summary>
        static readonly char[] separators = { ' ', '.', ',', ':', ';', '!', '?', '\"', '\'', '(', ')', '{', '}', '[', ']', '<', '>', '/', '\\', '|', '@', '#', '$', '%', '&', '^', '*', '+', '=', '-', '_', '`', '~' };

        /// <summary>
        /// Form constructor - starts ScanAgentThread
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ScanAgent));
        }

        /// <summary>
        /// Add new files
        /// </summary>
        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            foreach (string fileName in openFileDialog.FileNames)
                fileQueue.Enqueue(fileName);
            scanAgentSignal.Set();
            SearchEngine.Properties.Settings.Default.Files = openFileDialog.FileName;
            GC.Collect();   /* Utilizes disposed BitArrays with old size */
        }

        /// <summary>
        /// Background method that adds files
        /// </summary>
        void ScanAgent(object stateInfo)
        {
        loop:
            int oldWordListCount = wordList.Count;  /* Required */
            // Wait until user will add new files to database
            scanAgentSignal.WaitOne();
            // For each file in queue that user has added
            while (fileQueue.Count > 0)
                // Try to add file to database. If file already exists then go to next file in queue
                try
                {
                    // Wait and lock access to all collections while processing current file
                    locker.AcquireWriterLock(Timeout.Infinite);
                    // Get file path
                    string fileName = fileQueue.Dequeue();
                    // Refresh action status on form
                    Invoke(new ThreadStart(delegate { toolStripLabel.Text = "Processing file: " + fileName; }));
                    // Create file index as stack of WordStructs
                    Stack<WordStruct> stack = new Stack<WordStruct>();
                    // Add new file index to collection
                    collections.Add(fileName, stack);
                    // Open file and split it to words
                    using (StreamReader streamReader = new StreamReader(fileName, Encoding.GetEncoding(1251)))
                        for (int ln = 0; !streamReader.EndOfStream; ln++)
                        {
                            string line = streamReader.ReadLine().ToLower();
                            foreach (string word in line.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                            {
                                // If word is not exists in dictionary yet then add it to dictionary
                                if (!wordList.Contains(word))
                                    wordList.Add(word);
                                // If word is not exists in current file yet then add it to collection
                                WordStruct wordStruct = new WordStruct(wordList.IndexOf(word), ln, line.IndexOf(word));
                                if (!stack.Contains(wordStruct, wordComparer))
                                    stack.Push(wordStruct);
                            }
                        }
                    // Resize all BitArrays
                    foreach (KeyValuePair<string, BitArray> pair in bitArrays)
                        pair.Value.Length = wordList.Count;
                    // Create file index as BitArray
                    bitArrays.Add(fileName, new BitArray(wordList.Count, false));
                    foreach (WordStruct word in stack)
                        bitArrays[fileName][word.index] = true;
                }
                catch (Exception error)
                {
                    // Could not open file or file already exists in database
                    if (MessageBox.Show(error.Message + "\nWould you like to continue?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        continue;
                    else
                        fileQueue.Clear();
                }
                finally
                {
                    // Allow search access to all collections
                    locker.ReleaseWriterLock();
                }
            // Update text on status label
            Invoke(new ThreadStart(delegate { toolStripLabel.Text = string.Format("Ready ({0} files)", collections.Count); }));
            goto loop;
        }

        /// <summary>
        /// Force search on button click
        /// </summary>
        private void buttonSearch_Click(object sender, EventArgs e)
        {     
            string requestString = textBox.Text.ToLower().Trim();
            // Clear previous results
            listBoxBitArray.Items.Clear();
            listBoxCollection.Items.Clear();
            // Start search threads
            ThreadPool.QueueUserWorkItem(new WaitCallback(SearchInBitArrays), requestString);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SearchInCollections), requestString);
        }

        /// <summary>
        /// Search in BitArrays
        /// </summary>
        void SearchInBitArrays(object requestString)
        {
            // Deny write access to all collections
            locker.AcquireReaderLock(Timeout.Infinite);
            // Maintain start time to get work time later
            DateTime startTime = DateTime.Now;
            // Create request vector from request string
            BitArray requestVector = new BitArray(wordList.Count, false);
            foreach (string word in requestString.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                int index = wordList.IndexOf(word);
                // Set each word occurance in vector
                if (index >= 0) requestVector[index] = true;
            }
            // Create collection of files that have at least one match
            Stack<string> matchFiles = new Stack<string>();
            // Check each file for one match at least and add to match files if satisfies
            foreach (KeyValuePair<string, BitArray> pair in bitArrays)
                if (((BitArray)pair.Value.Clone()).And(requestVector).Cast<bool>().Contains(true))
                    matchFiles.Push(pair.Key);
            // Allow write access to all collections
            locker.ReleaseReaderLock();
            // Get work time
            int ms = (DateTime.Now - startTime).Milliseconds;
            // Show results
            Invoke(new ThreadStart(delegate
                { 
                    groupBoxBitArrays.Text = string.Format("BitArray results ({0} ms)", ms);
                    foreach (string fileName in matchFiles)
                        listBoxBitArray.Items.Add(fileName);
                }));
        }

        /// <summary>
        /// Search in collections
        /// </summary>
        void SearchInCollections(object requestString)
        {
            // Deny write access to all collections
            locker.AcquireReaderLock(Timeout.Infinite);
            // Maintain start time to get work time later
            DateTime startTime = DateTime.Now;
            // Create collection of recuested words indeces
            Stack<WordStruct> requestCollection = new Stack<WordStruct>();
            foreach (string word in requestString.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries))
                requestCollection.Push(new WordStruct(wordList.IndexOf(word), 0, 0));
            // Find files that heave at least one match and add them into collection
            Dictionary<string, IEnumerable<WordStruct>> matchFiles = new Dictionary<string, IEnumerable<WordStruct>>();
            // Intersect each file index with requested collection of word indeces
            foreach (KeyValuePair<string, Stack<WordStruct>> pair in collections)
            {
                IEnumerable<WordStruct> intersect = pair.Value.Intersect(requestCollection, wordComparer);
                // If intersect is not empty then add it to match files
                if (intersect.Count() > 0)
                    matchFiles.Add(pair.Key, intersect);
            }
            // Allow write access to all collections
            locker.ReleaseReaderLock();
            // Get work time
            int ms = (DateTime.Now - startTime).Milliseconds;
            // Show results
            Invoke(new ThreadStart(delegate
            {
                groupBoxCollection.Text = string.Format("Collection results ({0} ms)", ms);
                foreach (KeyValuePair<string, IEnumerable<WordStruct>> pair in matchFiles)
                {
                    listBoxCollection.Items.Add(pair.Key);
                    string item = string.Empty;
                    foreach (WordStruct wordStruct in pair.Value)
                        item += string.Format("\t\"{0}\" (ln {1}, col {2});", wordList[wordStruct.index], wordStruct.ln, wordStruct.col);
                    listBoxCollection.Items.Add(item);
                }
            }));
        }

        /// <summary>
        /// Class to comapre WordStructs depending on their indeces
        /// </summary>
        class WordComparer : IEqualityComparer<WordStruct>
        {
            public bool Equals(WordStruct word1, WordStruct word2)
            {
                return word1.index == word2.index;
            }

            public int GetHashCode(WordStruct word)
            {
                return word.index;
            }
        }
    }
}
