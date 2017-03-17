namespace Automat
{
    partial class FormAutomat
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
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.comboBoxPut = new System.Windows.Forms.ComboBox();
            this.buttonPut = new System.Windows.Forms.Button();
            this.labelChink = new System.Windows.Forms.Label();
            this.checkBoxGenerate = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 12);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(634, 355);
            this.listBoxLog.TabIndex = 0;
            // 
            // comboBoxPut
            // 
            this.comboBoxPut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPut.FormattingEnabled = true;
            this.comboBoxPut.Items.AddRange(new object[] {
            "100",
            "50",
            "25",
            "10",
            "5",
            "2",
            "1"});
            this.comboBoxPut.Location = new System.Drawing.Point(320, 382);
            this.comboBoxPut.Name = "comboBoxPut";
            this.comboBoxPut.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPut.TabIndex = 2;
            // 
            // buttonPut
            // 
            this.buttonPut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPut.Location = new System.Drawing.Point(447, 382);
            this.buttonPut.Name = "buttonPut";
            this.buttonPut.Size = new System.Drawing.Size(75, 23);
            this.buttonPut.TabIndex = 3;
            this.buttonPut.Text = "Вкинути";
            this.buttonPut.UseVisualStyleBackColor = true;
            this.buttonPut.Click += new System.EventHandler(this.buttonPut_Click);
            // 
            // labelChink
            // 
            this.labelChink.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelChink.AutoSize = true;
            this.labelChink.Location = new System.Drawing.Point(222, 385);
            this.labelChink.Name = "labelChink";
            this.labelChink.Size = new System.Drawing.Size(92, 13);
            this.labelChink.TabIndex = 4;
            this.labelChink.Text = "Номінал монети:";
            // 
            // checkBoxGenerate
            // 
            this.checkBoxGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxGenerate.AutoSize = true;
            this.checkBoxGenerate.Location = new System.Drawing.Point(592, 388);
            this.checkBoxGenerate.Name = "checkBoxGenerate";
            this.checkBoxGenerate.Size = new System.Drawing.Size(199, 17);
            this.checkBoxGenerate.TabIndex = 5;
            this.checkBoxGenerate.Text = "Генерувати випадкові вкидування";
            this.checkBoxGenerate.UseVisualStyleBackColor = true;
            this.checkBoxGenerate.CheckedChanged += new System.EventHandler(this.checkBoxGenerate_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(59, 24);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(59, 50);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.ThousandsSeparator = true;
            this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(59, 76);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.ThousandsSeparator = true;
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(59, 102);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown4.TabIndex = 6;
            this.numericUpDown4.ThousandsSeparator = true;
            this.numericUpDown4.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(59, 128);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown5.TabIndex = 6;
            this.numericUpDown5.ThousandsSeparator = true;
            this.numericUpDown5.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(59, 154);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown6.TabIndex = 6;
            this.numericUpDown6.ThousandsSeparator = true;
            this.numericUpDown6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(59, 180);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown7.TabIndex = 6;
            this.numericUpDown7.ThousandsSeparator = true;
            this.numericUpDown7.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "100 коп";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "50 коп";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "25 коп";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "10 коп";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "5 коп";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "2 коп";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "1 коп";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(652, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 206);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Казна автомату";
            // 
            // FormAutomat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 419);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxGenerate);
            this.Controls.Add(this.labelChink);
            this.Controls.Add(this.buttonPut);
            this.Controls.Add(this.comboBoxPut);
            this.Controls.Add(this.listBoxLog);
            this.MinimumSize = new System.Drawing.Size(750, 330);
            this.Name = "FormAutomat";
            this.Text = "Подольський Сергій КВ-64  \"Автомат для розміну монет\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutomat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ComboBox comboBoxPut;
        private System.Windows.Forms.Button buttonPut;
        private System.Windows.Forms.Label labelChink;
        private System.Windows.Forms.CheckBox checkBoxGenerate;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

