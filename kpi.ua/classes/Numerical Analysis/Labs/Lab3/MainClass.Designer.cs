namespace NumLab3
{
    partial class MainClass
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.listBox = new System.Windows.Forms.ListBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.radioButtonGaussJordan = new System.Windows.Forms.RadioButton();
            this.radioButtonDirectIteration = new System.Windows.Forms.RadioButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDownEps = new System.Windows.Forms.NumericUpDown();
            this.labelEps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEps)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.Size = new System.Drawing.Size(310, 181);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(45, 27);
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownSize.TabIndex = 1;
            this.numericUpDownSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(328, 54);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(183, 173);
            this.listBox.TabIndex = 2;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(9, 29);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Size:";
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button.Location = new System.Drawing.Point(394, 271);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(117, 35);
            this.button.TabIndex = 3;
            this.button.Text = "Solve";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox.Controls.Add(this.labelEps);
            this.groupBox.Controls.Add(this.numericUpDownEps);
            this.groupBox.Controls.Add(this.radioButtonGaussJordan);
            this.groupBox.Controls.Add(this.radioButtonDirectIteration);
            this.groupBox.Location = new System.Drawing.Point(12, 240);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(243, 66);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Method:";
            // 
            // radioButtonGaussJordan
            // 
            this.radioButtonGaussJordan.AutoSize = true;
            this.radioButtonGaussJordan.Checked = true;
            this.radioButtonGaussJordan.Location = new System.Drawing.Point(7, 19);
            this.radioButtonGaussJordan.Name = "radioButtonGaussJordan";
            this.radioButtonGaussJordan.Size = new System.Drawing.Size(128, 17);
            this.radioButtonGaussJordan.TabIndex = 0;
            this.radioButtonGaussJordan.TabStop = true;
            this.radioButtonGaussJordan.Text = "Gauss-Jordan method";
            this.radioButtonGaussJordan.UseVisualStyleBackColor = true;
            this.radioButtonGaussJordan.CheckedChanged += new System.EventHandler(this.radioButtonGaussJordan_CheckedChanged);
            // 
            // radioButtonDirectIteration
            // 
            this.radioButtonDirectIteration.AutoSize = true;
            this.radioButtonDirectIteration.Location = new System.Drawing.Point(7, 42);
            this.radioButtonDirectIteration.Name = "radioButtonDirectIteration";
            this.radioButtonDirectIteration.Size = new System.Drawing.Size(93, 17);
            this.radioButtonDirectIteration.TabIndex = 0;
            this.radioButtonDirectIteration.TabStop = true;
            this.radioButtonDirectIteration.Text = "Direct iteration";
            this.radioButtonDirectIteration.UseVisualStyleBackColor = true;
            this.radioButtonDirectIteration.CheckedChanged += new System.EventHandler(this.radioButtonGaussJordan_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(523, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToFileToolStripMenuItem,
            this.loadFromFileToolStripMenuItem});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to file";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadFromFileToolStripMenuItem.Text = "Load from file";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.xml";
            this.openFileDialog.Filter = "XML table|*.xml|All files|*.*";
            this.openFileDialog.Title = "Load table";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xml";
            this.saveFileDialog.FileName = "table";
            this.saveFileDialog.Filter = "XML table|*.xml|All files|*.*";
            this.saveFileDialog.Title = "Save table";
            // 
            // numericUpDownEps
            // 
            this.numericUpDownEps.Location = new System.Drawing.Point(190, 42);
            this.numericUpDownEps.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownEps.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.numericUpDownEps.Name = "numericUpDownEps";
            this.numericUpDownEps.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownEps.TabIndex = 7;
            this.numericUpDownEps.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // labelEps
            // 
            this.labelEps.AutoSize = true;
            this.labelEps.Location = new System.Drawing.Point(129, 46);
            this.labelEps.Name = "labelEps";
            this.labelEps.Size = new System.Drawing.Size(55, 13);
            this.labelEps.TabIndex = 8;
            this.labelEps.Text = "Eps = 10^";
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 318);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.button);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainClass";
            this.Text = "Linear system by Sergey Podolsky";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButtonGaussJordan;
        private System.Windows.Forms.RadioButton radioButtonDirectIteration;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NumericUpDown numericUpDownEps;
        private System.Windows.Forms.Label labelEps;
    }
}

