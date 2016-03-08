using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Parser.Properties;

namespace Parser
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Form constructor
        /// </summary>
        /// <param name="args">File path to open at startup</param>
        public FormMain(string[] args)
        {
            InitializeComponent();
            // Open file on startup if set
            if (args.Length > 0)
                try
                {
                    richTextBox.LoadFile(args[0], RichTextBoxStreamType.PlainText);
                    saveFileDialog.FileName = openFileDialog.FileName = args[0];
                    richTextBox.Modified = false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// Show SaveFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    openFileDialog.FileName = saveFileDialog.FileName;
                    richTextBox.Modified = false;
                }
                catch (Exception exception)
                {
                    if (MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        saveAsToolStripMenuItem_Click(null, null);
                }
        }

        /// <summary>
        /// Open file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    saveFileDialog.FileName = openFileDialog.FileName;
                    richTextBox.Modified = false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                richTextBox.Modified = false;
            }
            catch
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        /// <summary>
        /// New file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.Modified)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
                else if (dialogResult == DialogResult.Cancel) return;
            }
            richTextBox.ResetText();
            saveFileDialog.FileName = "*.txt";
        }

        /*################################## PARSER CODE ###########################################*/

        /// <summary>
        /// AtoResetEvent to read each char on signal
        /// </summary>
        AutoResetEvent signal = new AutoResetEvent(false);

        /// <summary>
        /// Flag to wait for a signal either not
        /// </summary>
        public bool wait;

        /// <summary>
        /// Thread of parser
        /// </summary>
        Thread thread;

        /// <summary>
        /// Write result structures to ListBox
        /// </summary>
        /// <param name="result">Result structures</param>
        public void WriteResult(IEnumerable<object> result, string margin)
        {
            foreach (object item in result)
            {
                if (item is Email)
                {
                    Email email = (Email)item;
                    listBox.Items.Add(margin + "Name:\t" + email.Name);
                    listBox.Items.Add(margin + "Domain (subdomains):");
                    foreach (string subdomain in email.Domain)
                        listBox.Items.Add(margin + "\t" + subdomain);
                    listBox.Items.Add(string.Empty);
                }
                if (item is string)
                {
                    listBox.Items.Add(margin + "Comment:\t" + item.ToString());
                    listBox.Items.Add(string.Empty);
                }
                else if (item is Section)
                {
                    Section section = (Section)item;
                    listBox.Items.Add(margin + "Section:");
                    listBox.Items.Add(margin + "\tName:\t" + section.Name);
                    listBox.Items.Add(margin + "\tValue:\t" + section.Value);
                    listBox.Items.Add(string.Empty);
                    WriteResult(section.Items, margin + '\t');
                }
                else if (item is Parameter)
                {
                    Parameter parameter = (Parameter)item;
                    listBox.Items.Add(margin + "Parameter:");
                    listBox.Items.Add(margin + "\tName:\t" + parameter.Name);
                    listBox.Items.Add(margin + "\tValue:\t" + parameter.Value);
                    listBox.Items.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Show current State Machine name and it's state while parsing
        /// </summary>
        public void ShowStatus(object state, object StateMachine)
        {
            Invoke(new Action(delegate
            {
                toolStripStatusLabelState.Text = state.ToString();
                toolStripStatusLabelStateMachine.Text = StateMachine.ToString();
            }));
        }

        /// <summary>
        /// Current char position
        /// </summary>
        int position = -1;

        /// <summary>
        /// Current char position - marks char in RichTextBox after changing
        /// </summary>
        int Position
        {
            get
            {
                return position;
            }
            set
            {
                // Clear selection
                richTextBox.SelectAll();
                richTextBox.SelectionBackColor = richTextBox.BackColor;
                // Select and mark current postion
                position = value;
                if (position < 0)
                    richTextBox.Select(0, 0);
                else if (position < richTextBox.Text.Length)
                {
                    richTextBox.Select(position, 1);
                    richTextBox.SelectionBackColor = Settings.Default.SelectionColor;
                    richTextBox.Select(position + 1, 0);
                }
                toolStripStatusLabelPosition.Text = value.ToString();
            }
        }

        /// <summary>
        /// Read one char from RichTextBox
        /// </summary>
        /// <returns>Char or EOF</returns>
        public char ReadChar()
        {
            if (wait) signal.WaitOne(Timeout.Infinite);
            char c = Program.Eof;
            Invoke(new Action(delegate
            {
                if (++Position < richTextBox.Text.Length)
                    c = richTextBox.Text[Position];
            }));
            return c;
        }

        /// <summary>
        /// Parse one char
        /// </summary>
        private void buttonStep_Click(object sender, EventArgs e)
        {
            if (thread.IsAlive)
                signal.Set();
        }

        /// <summary>
        /// Parse all
        /// </summary>
        private void buttonParse_Click(object sender, EventArgs e)
        {
            wait = false;
            signal.Set();
        }

        /// <summary>
        /// Reset parsing
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            wait = true;
            Position = -1;
            if (thread != null && thread.IsAlive) thread.Abort();
            int selectedIndex = comboBox.SelectedIndex;
            (thread = new Thread(new ThreadStart(delegate
            {
                try
                {
                    if (selectedIndex == 0)
                        new StateMachineEmail().Parse();
                    else
                        new StateMachineMain().Parse();
                }
                catch (SyntaxException error)
                {
                    MessageBox.Show(this, error.Message, "Syntax error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }))).Start();
            listBox.Items.Clear();
            ShowStatus("Ready", "Main");
        }

        /// <summary>
        /// Abort thread on closing
        /// </summary>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.IsAlive)
                thread.Abort();
        }

        /// <summary>
        /// Set input file type to Email list
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBox.SelectedIndex = 0;
        }
    }
}
