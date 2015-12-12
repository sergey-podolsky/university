using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FormClipboardHistory : Form
    {
        /// <summary>
        /// Allows access to richTextBox
        /// </summary>
        RichTextBox richTextBox;

        /// <summary>
        /// Clipboard history form
        /// </summary>
        /// <param name="fMain">Parent form with richTextBox</param>
        public FormClipboardHistory(RichTextBox rtb)
        {
            InitializeComponent();
            richTextBox = rtb;
        }

        /// <summary>
        /// Add text to clipboard history
        /// </summary>
        /// <param name="text">Text to add</param>
        public void AddToHistory(string text)
        {
            if (multiLineListBox.Items.Count == 0 || multiLineListBox.Items[multiLineListBox.Items.Count - 1].ToString() != text)
                multiLineListBox.Items.Add(text);
        }

        /// <summary>
        /// Hide form on closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClipboardHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Paste selected text text to notepad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonPasteToNotepad_Click(object sender, EventArgs e)
        {
            if (multiLineListBox.SelectedIndex > -1)
                richTextBox.SelectedText = multiLineListBox.SelectedItem.ToString();
        }

        /// <summary>
        /// Delete selected text from hitory list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDeleteFromHistory_Click(object sender, EventArgs e)
        {
            multiLineListBox.Items.Remove(multiLineListBox.SelectedItem);
        }

        /// <summary>
        /// Copy selected text to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (multiLineListBox.SelectedIndex > -1)
                Clipboard.SetText(multiLineListBox.SelectedItem.ToString(), TextDataFormat.Rtf);
        }

        /// <summary>
        /// Claar all history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonClearAll_Click(object sender, EventArgs e)
        {
            multiLineListBox.Items.Clear();
        }

        /// <summary>
        /// Close on Esc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClipboardHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) Hide();
        }
    }
}
