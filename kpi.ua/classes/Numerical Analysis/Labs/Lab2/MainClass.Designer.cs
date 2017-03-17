namespace NumLab2
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
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.button = new System.Windows.Forms.Button();
            this.dataGridViewI = new System.Windows.Forms.DataGridView();
            this.epsI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRootValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEstimationOfExactness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewB = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewN = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownMinEps = new System.Windows.Forms.NumericUpDown();
            this.labelStepEps = new System.Windows.Forms.Label();
            this.numericUpDownMaxEps = new System.Windows.Forms.NumericUpDown();
            this.labelMaxEps = new System.Windows.Forms.Label();
            this.numericUpDownStepEps = new System.Windows.Forms.NumericUpDown();
            this.labelMinEps = new System.Windows.Forms.Label();
            this.labelMinX = new System.Windows.Forms.Label();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIterationsI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewN)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxX
            // 
            this.groupBoxX.Controls.Add(this.labelMinX);
            this.groupBoxX.Controls.Add(this.numericUpDownA);
            this.groupBoxX.Controls.Add(this.labelMaxX);
            this.groupBoxX.Controls.Add(this.numericUpDownB);
            this.groupBoxX.Location = new System.Drawing.Point(12, 12);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Size = new System.Drawing.Size(102, 91);
            this.groupBoxX.TabIndex = 0;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "Roots isolation";
            // 
            // button
            // 
            this.button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button.Location = new System.Drawing.Point(263, 367);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(126, 23);
            this.button.TabIndex = 1;
            this.button.Text = "Proceed";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // dataGridViewI
            // 
            this.dataGridViewI.AllowUserToAddRows = false;
            this.dataGridViewI.AllowUserToDeleteRows = false;
            this.dataGridViewI.AllowUserToResizeRows = false;
            this.dataGridViewI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.epsI,
            this.ColumnRootValue,
            this.ColumnEstimationOfExactness});
            this.dataGridViewI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewI.Location = new System.Drawing.Point(15, 195);
            this.dataGridViewI.Name = "dataGridViewI";
            this.dataGridViewI.ReadOnly = true;
            this.dataGridViewI.RowHeadersVisible = false;
            this.dataGridViewI.Size = new System.Drawing.Size(309, 156);
            this.dataGridViewI.TabIndex = 16;
            // 
            // epsI
            // 
            this.epsI.HeaderText = "eps(i)";
            this.epsI.Name = "epsI";
            this.epsI.ReadOnly = true;
            this.epsI.Width = 57;
            // 
            // ColumnRootValue
            // 
            this.ColumnRootValue.HeaderText = "Root value";
            this.ColumnRootValue.Name = "ColumnRootValue";
            this.ColumnRootValue.ReadOnly = true;
            this.ColumnRootValue.Width = 84;
            // 
            // ColumnEstimationOfExactness
            // 
            this.ColumnEstimationOfExactness.HeaderText = "Estimation of exactness";
            this.ColumnEstimationOfExactness.Name = "ColumnEstimationOfExactness";
            this.ColumnEstimationOfExactness.ReadOnly = true;
            this.ColumnEstimationOfExactness.Width = 131;
            // 
            // dataGridViewB
            // 
            this.dataGridViewB.AllowUserToAddRows = false;
            this.dataGridViewB.AllowUserToDeleteRows = false;
            this.dataGridViewB.AllowUserToResizeRows = false;
            this.dataGridViewB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewB.Location = new System.Drawing.Point(330, 195);
            this.dataGridViewB.Name = "dataGridViewB";
            this.dataGridViewB.ReadOnly = true;
            this.dataGridViewB.RowHeadersVisible = false;
            this.dataGridViewB.Size = new System.Drawing.Size(303, 156);
            this.dataGridViewB.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "eps(i)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 57;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Root value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Estimation of exactness";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 131;
            // 
            // dataGridViewN
            // 
            this.dataGridViewN.AllowUserToAddRows = false;
            this.dataGridViewN.AllowUserToDeleteRows = false;
            this.dataGridViewN.AllowUserToResizeRows = false;
            this.dataGridViewN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.ColumnIterationsI,
            this.ColumnB});
            this.dataGridViewN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewN.Location = new System.Drawing.Point(341, 26);
            this.dataGridViewN.Name = "dataGridViewN";
            this.dataGridViewN.ReadOnly = true;
            this.dataGridViewN.RowHeadersVisible = false;
            this.dataGridViewN.Size = new System.Drawing.Size(292, 136);
            this.dataGridViewN.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownMinEps);
            this.groupBox1.Controls.Add(this.labelStepEps);
            this.groupBox1.Controls.Add(this.numericUpDownMaxEps);
            this.groupBox1.Controls.Add(this.labelMaxEps);
            this.groupBox1.Controls.Add(this.numericUpDownStepEps);
            this.groupBox1.Controls.Add(this.labelMinEps);
            this.groupBox1.Location = new System.Drawing.Point(120, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 91);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "eps";
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
            // labelStepEps
            // 
            this.labelStepEps.AutoSize = true;
            this.labelStepEps.Location = new System.Drawing.Point(25, 68);
            this.labelStepEps.Name = "labelStepEps";
            this.labelStepEps.Size = new System.Drawing.Size(53, 13);
            this.labelStepEps.TabIndex = 8;
            this.labelStepEps.Text = "Step: 10^";
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
            // labelMaxEps
            // 
            this.labelMaxEps.AutoSize = true;
            this.labelMaxEps.Location = new System.Drawing.Point(3, 42);
            this.labelMaxEps.Name = "labelMaxEps";
            this.labelMaxEps.Size = new System.Drawing.Size(75, 13);
            this.labelMaxEps.TabIndex = 8;
            this.labelMaxEps.Text = "Maximum: 10^";
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
            // labelMinEps
            // 
            this.labelMinEps.AutoSize = true;
            this.labelMinEps.Location = new System.Drawing.Point(6, 16);
            this.labelMinEps.Name = "labelMinEps";
            this.labelMinEps.Size = new System.Drawing.Size(72, 13);
            this.labelMinEps.TabIndex = 8;
            this.labelMinEps.Text = "Minimum: 10^";
            // 
            // labelMinX
            // 
            this.labelMinX.AutoSize = true;
            this.labelMinX.Location = new System.Drawing.Point(6, 16);
            this.labelMinX.Name = "labelMinX";
            this.labelMinX.Size = new System.Drawing.Size(25, 13);
            this.labelMinX.TabIndex = 15;
            this.labelMinX.Text = "a = ";
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.DecimalPlaces = 1;
            this.numericUpDownA.Location = new System.Drawing.Point(37, 14);
            this.numericUpDownA.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownA.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownA.TabIndex = 13;
            this.numericUpDownA.Value = new decimal(new int[] {
            15,
            0,
            0,
            -2147418112});
            // 
            // labelMaxX
            // 
            this.labelMaxX.AutoSize = true;
            this.labelMaxX.Location = new System.Drawing.Point(6, 42);
            this.labelMaxX.Name = "labelMaxX";
            this.labelMaxX.Size = new System.Drawing.Size(25, 13);
            this.labelMaxX.TabIndex = 16;
            this.labelMaxX.Text = "b = ";
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.DecimalPlaces = 1;
            this.numericUpDownB.Location = new System.Drawing.Point(37, 38);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownB.TabIndex = 14;
            this.numericUpDownB.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Method of successive approximations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Bisection method";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "eps(i)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 57;
            // 
            // ColumnIterationsI
            // 
            this.ColumnIterationsI.HeaderText = "I";
            this.ColumnIterationsI.Name = "ColumnIterationsI";
            this.ColumnIterationsI.ReadOnly = true;
            this.ColumnIterationsI.Width = 35;
            // 
            // ColumnB
            // 
            this.ColumnB.HeaderText = "B";
            this.ColumnB.Name = "ColumnB";
            this.ColumnB.ReadOnly = true;
            this.ColumnB.Width = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Both methods\' iterations";
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 402);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewN);
            this.Controls.Add(this.dataGridViewB);
            this.Controls.Add(this.dataGridViewI);
            this.Controls.Add(this.button);
            this.Controls.Add(this.groupBoxX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainClass";
            this.Text = "15/x-x^2+15=0 by Sergey Podolsky";
            this.groupBoxX.ResumeLayout(false);
            this.groupBoxX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataGridView dataGridViewI;
        private System.Windows.Forms.DataGridViewTextBoxColumn epsI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRootValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEstimationOfExactness;
        private System.Windows.Forms.DataGridView dataGridViewB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dataGridViewN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinEps;
        private System.Windows.Forms.Label labelStepEps;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxEps;
        private System.Windows.Forms.Label labelMaxEps;
        private System.Windows.Forms.NumericUpDown numericUpDownStepEps;
        private System.Windows.Forms.Label labelMinEps;
        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIterationsI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

