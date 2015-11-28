namespace NetworkRouting
{
    partial class FormEdgeProperties
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
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.labelWeight = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxEdgeEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHalf = new System.Windows.Forms.RadioButton();
            this.radioButtonFull = new System.Windows.Forms.RadioButton();
            this.numericUpDownErrorRate = new System.Windows.Forms.NumericUpDown();
            this.labelErrorRate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorRate)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.Location = new System.Drawing.Point(12, 29);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownWeight.TabIndex = 0;
            this.numericUpDownWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(9, 13);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(69, 13);
            this.labelWeight.TabIndex = 1;
            this.labelWeight.Text = "Edge weight:";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(12, 188);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(93, 188);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxEdgeEnabled
            // 
            this.checkBoxEdgeEnabled.AutoSize = true;
            this.checkBoxEdgeEnabled.Location = new System.Drawing.Point(12, 66);
            this.checkBoxEdgeEnabled.Name = "checkBoxEdgeEnabled";
            this.checkBoxEdgeEnabled.Size = new System.Drawing.Size(102, 17);
            this.checkBoxEdgeEnabled.TabIndex = 3;
            this.checkBoxEdgeEnabled.Text = "Edge is enabled";
            this.checkBoxEdgeEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonHalf);
            this.groupBox1.Controls.Add(this.radioButtonFull);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel type";
            // 
            // radioButtonHalf
            // 
            this.radioButtonHalf.AutoSize = true;
            this.radioButtonHalf.Location = new System.Drawing.Point(12, 42);
            this.radioButtonHalf.Name = "radioButtonHalf";
            this.radioButtonHalf.Size = new System.Drawing.Size(78, 17);
            this.radioButtonHalf.TabIndex = 0;
            this.radioButtonHalf.TabStop = true;
            this.radioButtonHalf.Text = "Half-duplex";
            this.radioButtonHalf.UseVisualStyleBackColor = true;
            // 
            // radioButtonFull
            // 
            this.radioButtonFull.AutoSize = true;
            this.radioButtonFull.Location = new System.Drawing.Point(12, 19);
            this.radioButtonFull.Name = "radioButtonFull";
            this.radioButtonFull.Size = new System.Drawing.Size(75, 17);
            this.radioButtonFull.TabIndex = 0;
            this.radioButtonFull.TabStop = true;
            this.radioButtonFull.Text = "Full-duplex";
            this.radioButtonFull.UseVisualStyleBackColor = true;
            // 
            // numericUpDownErrorRate
            // 
            this.numericUpDownErrorRate.DecimalPlaces = 2;
            this.numericUpDownErrorRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownErrorRate.Location = new System.Drawing.Point(102, 29);
            this.numericUpDownErrorRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownErrorRate.Name = "numericUpDownErrorRate";
            this.numericUpDownErrorRate.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownErrorRate.TabIndex = 5;
            // 
            // labelErrorRate
            // 
            this.labelErrorRate.AutoSize = true;
            this.labelErrorRate.Location = new System.Drawing.Point(99, 13);
            this.labelErrorRate.Name = "labelErrorRate";
            this.labelErrorRate.Size = new System.Drawing.Size(53, 13);
            this.labelErrorRate.TabIndex = 6;
            this.labelErrorRate.Text = "Error rate:";
            // 
            // FormEdgeProperties
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(185, 223);
            this.Controls.Add(this.labelErrorRate);
            this.Controls.Add(this.numericUpDownErrorRate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxEdgeEnabled);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.numericUpDownWeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEdgeProperties";
            this.Text = "Edge properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxEdgeEnabled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonHalf;
        private System.Windows.Forms.RadioButton radioButtonFull;
        private System.Windows.Forms.NumericUpDown numericUpDownErrorRate;
        private System.Windows.Forms.Label labelErrorRate;
    }
}