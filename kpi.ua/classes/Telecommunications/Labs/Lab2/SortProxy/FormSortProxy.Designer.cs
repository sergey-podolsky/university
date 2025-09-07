namespace SortProxy
{
    partial class FormSortProxy
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxRandom = new System.Windows.Forms.ListBox();
            this.listBoxSorted = new System.Windows.Forms.ListBox();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.labelSize = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.buttonSort = new System.Windows.Forms.Button();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(12, 32);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBoxRandom);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listBoxSorted);
            this.splitContainer.Size = new System.Drawing.Size(546, 376);
            this.splitContainer.SplitterDistance = 178;
            this.splitContainer.TabIndex = 14;
            // 
            // listBoxRandom
            // 
            this.listBoxRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRandom.FormattingEnabled = true;
            this.listBoxRandom.HorizontalScrollbar = true;
            this.listBoxRandom.Location = new System.Drawing.Point(0, 0);
            this.listBoxRandom.Name = "listBoxRandom";
            this.listBoxRandom.ScrollAlwaysVisible = true;
            this.listBoxRandom.Size = new System.Drawing.Size(542, 173);
            this.listBoxRandom.TabIndex = 0;
            // 
            // listBoxSorted
            // 
            this.listBoxSorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSorted.FormattingEnabled = true;
            this.listBoxSorted.HorizontalScrollbar = true;
            this.listBoxSorted.Location = new System.Drawing.Point(0, 0);
            this.listBoxSorted.Name = "listBoxSorted";
            this.listBoxSorted.ScrollAlwaysVisible = true;
            this.listBoxSorted.Size = new System.Drawing.Size(542, 186);
            this.listBoxSorted.TabIndex = 0;
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomize.Location = new System.Drawing.Point(430, 4);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(128, 23);
            this.buttonRandomize.TabIndex = 13;
            this.buttonRandomize.Text = "Create random matrix";
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.buttonRandomize_Click);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(12, 9);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(59, 13);
            this.labelSize.TabIndex = 12;
            this.labelSize.Text = "Matrix size:";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(77, 5);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownSize.TabIndex = 11;
            this.numericUpDownSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonSort
            // 
            this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSort.Location = new System.Drawing.Point(430, 414);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(128, 23);
            this.buttonSort.TabIndex = 8;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // FormSortProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 446);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.buttonSort);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormSortProxy";
            this.Text = "SortProxy by Podolsky Sergey KV-64";
            this.Load += new System.EventHandler(this.FormSortProxy_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxRandom;
        private System.Windows.Forms.ListBox listBoxSorted;
        private System.Windows.Forms.Button buttonRandomize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Button buttonSort;
    }
}

