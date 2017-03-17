namespace NumLab1
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
            this.numericUpDownMaxEps = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinEps = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStepEps = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.labelMinEps = new System.Windows.Forms.Label();
            this.labelMaxEps = new System.Windows.Forms.Label();
            this.labelStepEps = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelStepCount = new System.Windows.Forms.Label();
            this.labelMinX = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.numericUpDownStepCount = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnEps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAbsoluteError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemainderTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnXi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAbsoluteError2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemainderTerm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownMaxEps
            // 
            this.numericUpDownMaxEps.Location = new System.Drawing.Point(84, 40);
            this.numericUpDownMaxEps.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownMaxEps.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownMaxEps.Name = "numericUpDownMaxEps";
            this.numericUpDownMaxEps.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownMaxEps.TabIndex = 0;
            this.numericUpDownMaxEps.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // numericUpDownMinEps
            // 
            this.numericUpDownMinEps.Location = new System.Drawing.Point(84, 14);
            this.numericUpDownMinEps.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownMinEps.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownMinEps.Name = "numericUpDownMinEps";
            this.numericUpDownMinEps.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownMinEps.TabIndex = 1;
            this.numericUpDownMinEps.Value = new decimal(new int[] {
            14,
            0,
            0,
            -2147483648});
            // 
            // numericUpDownStepEps
            // 
            this.numericUpDownStepEps.Location = new System.Drawing.Point(84, 66);
            this.numericUpDownStepEps.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownStepEps.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownStepEps.Name = "numericUpDownStepEps";
            this.numericUpDownStepEps.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownStepEps.TabIndex = 2;
            this.numericUpDownStepEps.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.DecimalPlaces = 2;
            this.numericUpDownA.Location = new System.Drawing.Point(37, 16);
            this.numericUpDownA.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownA.TabIndex = 3;
            this.numericUpDownA.Value = new decimal(new int[] {
            1037,
            0,
            0,
            131072});
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.DecimalPlaces = 2;
            this.numericUpDownB.Location = new System.Drawing.Point(37, 40);
            this.numericUpDownB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownB.TabIndex = 4;
            this.numericUpDownB.Value = new decimal(new int[] {
            374,
            0,
            0,
            65536});
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(37, 66);
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownN.TabIndex = 4;
            this.numericUpDownN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelMinEps
            // 
            this.labelMinEps.AutoSize = true;
            this.labelMinEps.Location = new System.Drawing.Point(6, 16);
            this.labelMinEps.Name = "labelMinEps";
            this.labelMinEps.Size = new System.Drawing.Size(72, 13);
            this.labelMinEps.TabIndex = 8;
            this.labelMinEps.Text = "Minimum: 10^";
            // 
            // labelMaxEps
            // 
            this.labelMaxEps.AutoSize = true;
            this.labelMaxEps.Location = new System.Drawing.Point(3, 42);
            this.labelMaxEps.Name = "labelMaxEps";
            this.labelMaxEps.Size = new System.Drawing.Size(75, 13);
            this.labelMaxEps.TabIndex = 8;
            this.labelMaxEps.Text = "Maximum: 10^";
            // 
            // labelStepEps
            // 
            this.labelStepEps.AutoSize = true;
            this.labelStepEps.Location = new System.Drawing.Point(25, 68);
            this.labelStepEps.Name = "labelStepEps";
            this.labelStepEps.Size = new System.Drawing.Size(53, 13);
            this.labelStepEps.TabIndex = 8;
            this.labelStepEps.Text = "Step: 10^";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownMinEps);
            this.groupBox1.Controls.Add(this.labelStepEps);
            this.groupBox1.Controls.Add(this.numericUpDownMaxEps);
            this.groupBox1.Controls.Add(this.labelMaxEps);
            this.groupBox1.Controls.Add(this.numericUpDownStepEps);
            this.groupBox1.Controls.Add(this.labelMinEps);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 99);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "eps";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelStepCount);
            this.groupBox2.Controls.Add(this.labelMinX);
            this.groupBox2.Controls.Add(this.labelN);
            this.groupBox2.Controls.Add(this.numericUpDownA);
            this.groupBox2.Controls.Add(this.labelMaxX);
            this.groupBox2.Controls.Add(this.numericUpDownB);
            this.groupBox2.Controls.Add(this.numericUpDownStepCount);
            this.groupBox2.Controls.Add(this.numericUpDownN);
            this.groupBox2.Location = new System.Drawing.Point(159, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 99);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Argument (x)";
            // 
            // labelStepCount
            // 
            this.labelStepCount.AutoSize = true;
            this.labelStepCount.Location = new System.Drawing.Point(100, 37);
            this.labelStepCount.Name = "labelStepCount";
            this.labelStepCount.Size = new System.Drawing.Size(98, 26);
            this.labelStepCount.TabIndex = 14;
            this.labelStepCount.Text = "Total step count\r\n(table 2 row count):\r\n";
            // 
            // labelMinX
            // 
            this.labelMinX.AutoSize = true;
            this.labelMinX.Location = new System.Drawing.Point(6, 18);
            this.labelMinX.Name = "labelMinX";
            this.labelMinX.Size = new System.Drawing.Size(25, 13);
            this.labelMinX.TabIndex = 11;
            this.labelMinX.Text = "a = ";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(6, 68);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(25, 13);
            this.labelN.TabIndex = 13;
            this.labelN.Text = "n = ";
            // 
            // labelMaxX
            // 
            this.labelMaxX.AutoSize = true;
            this.labelMaxX.Location = new System.Drawing.Point(6, 44);
            this.labelMaxX.Name = "labelMaxX";
            this.labelMaxX.Size = new System.Drawing.Size(25, 13);
            this.labelMaxX.TabIndex = 12;
            this.labelMaxX.Text = "b = ";
            // 
            // numericUpDownStepCount
            // 
            this.numericUpDownStepCount.Location = new System.Drawing.Point(103, 66);
            this.numericUpDownStepCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStepCount.Name = "numericUpDownStepCount";
            this.numericUpDownStepCount.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownStepCount.TabIndex = 4;
            this.numericUpDownStepCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEps,
            this.ColumnN,
            this.ColumnAbsoluteError,
            this.ColumnRemainderTerm});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(352, 150);
            this.dataGridView1.TabIndex = 15;
            // 
            // ColumnEps
            // 
            this.ColumnEps.HeaderText = "eps";
            this.ColumnEps.Name = "ColumnEps";
            this.ColumnEps.ReadOnly = true;
            this.ColumnEps.Width = 49;
            // 
            // ColumnN
            // 
            this.ColumnN.HeaderText = "n";
            this.ColumnN.Name = "ColumnN";
            this.ColumnN.ReadOnly = true;
            this.ColumnN.Width = 38;
            // 
            // ColumnAbsoluteError
            // 
            this.ColumnAbsoluteError.HeaderText = "Absolute error";
            this.ColumnAbsoluteError.Name = "ColumnAbsoluteError";
            this.ColumnAbsoluteError.ReadOnly = true;
            this.ColumnAbsoluteError.Width = 89;
            // 
            // ColumnRemainderTerm
            // 
            this.ColumnRemainderTerm.HeaderText = "Remainder term";
            this.ColumnRemainderTerm.Name = "ColumnRemainderTerm";
            this.ColumnRemainderTerm.ReadOnly = true;
            this.ColumnRemainderTerm.Width = 97;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnXi,
            this.ColumnAbsoluteError2,
            this.ColumnRemainderTerm2});
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(12, 273);
            this.dataGridView2.MinimumSize = new System.Drawing.Size(352, 137);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(352, 137);
            this.dataGridView2.TabIndex = 16;
            // 
            // ColumnXi
            // 
            this.ColumnXi.HeaderText = "Xi";
            this.ColumnXi.Name = "ColumnXi";
            this.ColumnXi.ReadOnly = true;
            this.ColumnXi.Width = 41;
            // 
            // ColumnAbsoluteError2
            // 
            this.ColumnAbsoluteError2.HeaderText = "Absolute error";
            this.ColumnAbsoluteError2.Name = "ColumnAbsoluteError2";
            this.ColumnAbsoluteError2.ReadOnly = true;
            this.ColumnAbsoluteError2.Width = 89;
            // 
            // ColumnRemainderTerm2
            // 
            this.ColumnRemainderTerm2.HeaderText = "Remainder term";
            this.ColumnRemainderTerm2.Name = "ColumnRemainderTerm2";
            this.ColumnRemainderTerm2.ReadOnly = true;
            this.ColumnRemainderTerm2.Width = 97;
            // 
            // button
            // 
            this.button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button.Location = new System.Drawing.Point(127, 416);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(123, 23);
            this.button.TabIndex = 17;
            this.button.Text = "Proceed";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 451);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(384, 478);
            this.Name = "MainClass";
            this.Text = "y=sin(x)  by Podolsky Sergey KV-64";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownMaxEps;
        private System.Windows.Forms.NumericUpDown numericUpDownMinEps;
        private System.Windows.Forms.NumericUpDown numericUpDownStepEps;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Label labelMinEps;
        private System.Windows.Forms.Label labelMaxEps;
        private System.Windows.Forms.Label labelStepEps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEps;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAbsoluteError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemainderTerm;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnXi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAbsoluteError2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemainderTerm2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label labelStepCount;
        private System.Windows.Forms.NumericUpDown numericUpDownStepCount;

    }
}

