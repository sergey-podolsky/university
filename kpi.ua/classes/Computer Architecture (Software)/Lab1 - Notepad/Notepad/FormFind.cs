using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FormFind : Form
    {
        /// <summary>
        /// RichTextBox to search text
        /// </summary>
        RichTextBox richTextBox;

        /// <summary>
        /// Find dialog
        /// </summary>
        /// <param name="rtb">RichTextBox to search text</param>
        public FormFind(RichTextBox rtb)
        {
            InitializeComponent();
            richTextBox = rtb;
        }

        /// <summary>
        /// Hide form on closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Recursive function to find and mark each match
        /// </summary>
        /// <param name="start">Start index in RichTextBox to search</param>
        /// <param name="matches">Matches found</param>
        int Find(int start, RichTextBoxFinds richTextBoxFinds)
        {
            if (richTextBox.Find(textBox.Text, start, richTextBoxFinds) > -1)
            {
                richTextBox.SelectionBackColor = Color.Gold;
                return richTextBox.SelectionStart + richTextBox.SelectionLength < richTextBox.Text.Length ?
                    Find(richTextBox.SelectionStart + richTextBox.SelectionLength, richTextBoxFinds) + 1
                    : 1;
            }
            return 0;
        }

        /// <summary>
        /// Unmark all highlited matches in RichTextBox
        /// </summary>
        void UnMarkAll()
        {
            int selectionStart = richTextBox.SelectionStart;
            int selectionLength = richTextBox.SelectionLength;
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = richTextBox.BackColor;
            richTextBox.Select(selectionStart, selectionLength);
        }

        /// <summary>
        /// Search specified text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, EventArgs e)
        {
            UnMarkAll();
            RichTextBoxFinds richTextBoxFinds = RichTextBoxFinds.None;
            if (checkBoxMatchCase.Checked) richTextBoxFinds |= RichTextBoxFinds.MatchCase;
            if (checkBoxWholeWords.Checked) richTextBoxFinds |= RichTextBoxFinds.WholeWord;
            labelMatches.Text = "Matches: " + Find(0, richTextBoxFinds).ToString();
        }

        /// <summary>
        /// Select textBox on Show and unmark all highlited matches in RichTextBox on Hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFind_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                textBox.Select();
                textBox.SelectAll();
                labelMatches.Text = "Ready";
            }
            else UnMarkAll();
        }

        /// <summary>
        /// Close on Esc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) Hide();
        }
    }
}
