namespace Notepad
{
    partial class FormClipboardHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClipboardHistory));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPasteToNotepad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyToClipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFromHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearAll = new System.Windows.Forms.ToolStripButton();
            this.multiLineListBox = new Notepad.MultiLineListBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPasteToNotepad,
            this.toolStripButtonCopyToClipboard,
            this.toolStripButtonRemoveFromHistory,
            this.toolStripButtonClearAll});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(458, 25);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonPasteToNotepad
            // 
            this.toolStripButtonPasteToNotepad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPasteToNotepad.Image")));
            this.toolStripButtonPasteToNotepad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPasteToNotepad.Name = "toolStripButtonPasteToNotepad";
            this.toolStripButtonPasteToNotepad.Size = new System.Drawing.Size(116, 22);
            this.toolStripButtonPasteToNotepad.Text = "Paste to notepad";
            this.toolStripButtonPasteToNotepad.Click += new System.EventHandler(this.toolStripButtonPasteToNotepad_Click);
            // 
            // toolStripButtonCopyToClipboard
            // 
            this.toolStripButtonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyToClipboard.Image")));
            this.toolStripButtonCopyToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyToClipboard.Name = "toolStripButtonCopyToClipboard";
            this.toolStripButtonCopyToClipboard.Size = new System.Drawing.Size(122, 22);
            this.toolStripButtonCopyToClipboard.Text = "Copy to clipboard";
            this.toolStripButtonCopyToClipboard.Click += new System.EventHandler(this.toolStripButtonCopyToClipboard_Click);
            // 
            // toolStripButtonRemoveFromHistory
            // 
            this.toolStripButtonRemoveFromHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveFromHistory.Image")));
            this.toolStripButtonRemoveFromHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveFromHistory.Name = "toolStripButtonRemoveFromHistory";
            this.toolStripButtonRemoveFromHistory.Size = new System.Drawing.Size(138, 22);
            this.toolStripButtonRemoveFromHistory.Text = "Remove from history";
            this.toolStripButtonRemoveFromHistory.Click += new System.EventHandler(this.toolStripButtonDeleteFromHistory_Click);
            // 
            // toolStripButtonClearAll
            // 
            this.toolStripButtonClearAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearAll.Image")));
            this.toolStripButtonClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearAll.Name = "toolStripButtonClearAll";
            this.toolStripButtonClearAll.Size = new System.Drawing.Size(69, 22);
            this.toolStripButtonClearAll.Text = "Clear all";
            this.toolStripButtonClearAll.Click += new System.EventHandler(this.toolStripButtonClearAll_Click);
            // 
            // multiLineListBox
            // 
            this.multiLineListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiLineListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiLineListBox.FormattingEnabled = true;
            this.multiLineListBox.Location = new System.Drawing.Point(0, 25);
            this.multiLineListBox.Name = "multiLineListBox";
            this.multiLineListBox.ScrollAlwaysVisible = true;
            this.multiLineListBox.Size = new System.Drawing.Size(458, 284);
            this.multiLineListBox.TabIndex = 8;
            // 
            // FormClipboardHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 309);
            this.Controls.Add(this.multiLineListBox);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormClipboardHistory";
            this.ShowInTaskbar = false;
            this.Text = "Clipboard history";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClipboardHistory_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormClipboardHistory_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyToClipboard;
        private System.Windows.Forms.ToolStripButton toolStripButtonPasteToNotepad;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFromHistory;
        private MultiLineListBox multiLineListBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearAll;

    }
}