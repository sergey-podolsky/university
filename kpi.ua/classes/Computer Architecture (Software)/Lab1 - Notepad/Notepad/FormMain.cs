using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Clipboard copy/cut history form
        /// </summary>
        FormClipboardHistory formClipboardHistory;

        /// <summary>
        /// Find dialog
        /// </summary>
        FormFind formFind;

        /// <summary>
        /// Notepad main form
        /// </summary>
        /// <param name="args">File to open</param>
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
        /// Initialize forms and events on startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            richTextBox.DataBindings.Add("WordWrap", wordWrapToolStripMenuItem, "Checked");
            statusStrip.DataBindings.Add("Visible", statusBarToolStripMenuItem, "Checked");
            formClipboardHistory = new FormClipboardHistory(richTextBox);
            formFind = new FormFind(richTextBox);
            timer_Tick(null, null);
            richTextBox_SelectionChanged(null, null);
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
            if (richTextBox.Modified)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
                else if (dialogResult == DialogResult.Cancel) return;
            }
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

        /// <summary>
        /// Hide and minimize window to system tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "Notepad hidden";
                notifyIcon.BalloonTipText = "Click here to restore Notepad window";
                notifyIcon.ShowBalloonTip(3000);
                Hide();
            }
        }

        /// <summary>
        /// Restore window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// Close notepad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Save prompt on closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox.Modified)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
                else if (e.Cancel = dialogResult == DialogResult.Cancel)
                    return;
            }
        }

        /// <summary>
        /// Current DateTime autoupdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDateTimeNow.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// Current line and column coords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelPosition.Text =
                string.Format("Ln {0}, Col {1}",
                richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart) + 1,
                richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine() + 1);
        }

        /// <summary>
        /// Transliterate selected text from EN into RU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EN_RU_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectionStart = richTextBox.SelectionStart;
            string result = richTextBox.SelectedText = Transliterate.EN_RU(richTextBox.SelectedText);
            richTextBox.Select(selectionStart, result.Length);
        }

        /// <summary>
        /// Transliterate selected text from RU into EN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RU_EN_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectionStart = richTextBox.SelectionStart;
            string result = richTextBox.SelectedText = Transliterate.RU_EN(richTextBox.SelectedText);
            richTextBox.Select(selectionStart, result.Length);
        }

        /// <summary>
        /// Undo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        /// <summary>
        /// Redo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        /// <summary>
        /// Cut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
            formClipboardHistory.AddToHistory(Clipboard.GetText(TextDataFormat.Text));
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
            formClipboardHistory.AddToHistory(Clipboard.GetText(TextDataFormat.Text));
        }

        /// <summary>
        /// Paste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = string.Empty;
        }

        /// <summary>
        /// Show Clipboard History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clipboardHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClipboardHistory.Show();
            formClipboardHistory.Activate();
        }

        /// <summary>
        /// Show find dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formFind.Show();
            formFind.Activate();
        }

        static readonly char[] wordSeparators = { ' ', ',', '.', ',', '!', '?', ':', ';', '\n', '\t' };

        /// <summary>
        /// Total count of words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countOfWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder(richTextBox.Text);
            for (int i = 0; i < stringBuilder.Length; i++)
                if (!char.IsLetterOrDigit(stringBuilder[i]))
                    stringBuilder[i] = ' ';
            MessageBox.Show("Total count of words in the text is " +
                stringBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count().ToString());
        }

        /// <summary>
        /// Total count of numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countOfNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder(richTextBox.Text);
            for (int i = 0; i < stringBuilder.Length; i++)
                if (!char.IsDigit(stringBuilder[i]))
                    stringBuilder[i] = ' ';
            MessageBox.Show("Total count of numbers in the text is " +
                stringBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count().ToString());
        }

        /// <summary>
        /// Total count of delimiters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countOfDelimitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] delimiters = { '.', ',', '!', '?', ':', ';' };
            char[] text = richTextBox.Text.ToCharArray();
            MessageBox.Show("Total count of delimiters is " +
                text.Count(
                    delegate(char c)
                    {
                        return delimiters.Contains(c);
                    }).ToString());
        }

        /// <summary>
        /// Average word length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void averageWordLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder(richTextBox.Text);
            for (int i = 0; i < stringBuilder.Length; i++)
                if (!char.IsLetterOrDigit(stringBuilder[i]))
                    stringBuilder[i] = ' ';
            string[] words = stringBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            MessageBox.Show("Average word length is " +
                (words.Length > 0 ?
                        words.Average(
                            delegate(string word)
                            {
                                return word.Length;
                            }).ToString()
                        : "0"));
        }

        /// <summary>
        /// Show AboutBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutNotepad().ShowDialog();
        }
    }
}
