namespace SearchEngine
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxBitArray = new System.Windows.Forms.ListBox();
            this.groupBoxBitArrays = new System.Windows.Forms.GroupBox();
            this.groupBoxCollection = new System.Windows.Forms.GroupBox();
            this.listBoxCollection = new System.Windows.Forms.ListBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip.SuspendLayout();
            this.groupBoxBitArrays.SuspendLayout();
            this.groupBoxCollection.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = global::SearchEngine.Properties.Settings.Default.Files;
            this.openFileDialog.Filter = "All files|*.*|Text files|*.txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Add text files";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButton
            // 
            this.toolStripButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton.Image")));
            this.toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton.Name = "toolStripButton";
            this.toolStripButton.Size = new System.Drawing.Size(75, 22);
            this.toolStripButton.Text = "Add files";
            this.toolStripButton.Click += new System.EventHandler(this.buttonAddFiles_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(112, 22);
            this.toolStripLabel.Text = "Dictionary is empty.";
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(12, 57);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(760, 20);
            this.textBox.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearch.Location = new System.Drawing.Point(321, 83);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(142, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // listBoxBitArray
            // 
            this.listBoxBitArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBitArray.FormattingEnabled = true;
            this.listBoxBitArray.HorizontalScrollbar = true;
            this.listBoxBitArray.Location = new System.Drawing.Point(3, 16);
            this.listBoxBitArray.Name = "listBoxBitArray";
            this.listBoxBitArray.ScrollAlwaysVisible = true;
            this.listBoxBitArray.Size = new System.Drawing.Size(754, 186);
            this.listBoxBitArray.TabIndex = 4;
            // 
            // groupBoxBitArrays
            // 
            this.groupBoxBitArrays.Controls.Add(this.listBoxBitArray);
            this.groupBoxBitArrays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBitArrays.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBitArrays.Name = "groupBoxBitArrays";
            this.groupBoxBitArrays.Size = new System.Drawing.Size(760, 214);
            this.groupBoxBitArrays.TabIndex = 5;
            this.groupBoxBitArrays.TabStop = false;
            this.groupBoxBitArrays.Text = "BitArray results";
            // 
            // groupBoxCollection
            // 
            this.groupBoxCollection.Controls.Add(this.listBoxCollection);
            this.groupBoxCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCollection.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCollection.Name = "groupBoxCollection";
            this.groupBoxCollection.Size = new System.Drawing.Size(760, 220);
            this.groupBoxCollection.TabIndex = 5;
            this.groupBoxCollection.TabStop = false;
            this.groupBoxCollection.Text = "Collection results";
            // 
            // listBoxCollection
            // 
            this.listBoxCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCollection.FormattingEnabled = true;
            this.listBoxCollection.HorizontalScrollbar = true;
            this.listBoxCollection.Location = new System.Drawing.Point(3, 16);
            this.listBoxCollection.Name = "listBoxCollection";
            this.listBoxCollection.ScrollAlwaysVisible = true;
            this.listBoxCollection.Size = new System.Drawing.Size(754, 199);
            this.listBoxCollection.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 112);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxBitArrays);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxCollection);
            this.splitContainer.Size = new System.Drawing.Size(760, 438);
            this.splitContainer.SplitterDistance = 214;
            this.splitContainer.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.toolStrip);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "FormMain";
            this.Text = "Podolsky Sergey KV-64";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBoxBitArrays.ResumeLayout(false);
            this.groupBoxCollection.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBoxBitArray;
        private System.Windows.Forms.GroupBox groupBoxBitArrays;
        private System.Windows.Forms.GroupBox groupBoxCollection;
        private System.Windows.Forms.ListBox listBoxCollection;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

