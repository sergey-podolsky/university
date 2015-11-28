namespace NetworkRouting
{
    partial class FormNodeProperties
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxNodeEnabled = new System.Windows.Forms.CheckBox();
            this.numericUpDownBufferSize = new System.Windows.Forms.NumericUpDown();
            this.labelBufferSize = new System.Windows.Forms.Label();
            this.numericUpDownDeadline = new System.Windows.Forms.NumericUpDown();
            this.labelDeadline = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadline)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(92, 145);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(11, 145);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxNodeEnabled
            // 
            this.checkBoxNodeEnabled.AutoSize = true;
            this.checkBoxNodeEnabled.Location = new System.Drawing.Point(40, 12);
            this.checkBoxNodeEnabled.Name = "checkBoxNodeEnabled";
            this.checkBoxNodeEnabled.Size = new System.Drawing.Size(103, 17);
            this.checkBoxNodeEnabled.TabIndex = 5;
            this.checkBoxNodeEnabled.Text = "Node is enabled";
            this.checkBoxNodeEnabled.UseVisualStyleBackColor = true;
            // 
            // numericUpDownBufferSize
            // 
            this.numericUpDownBufferSize.Location = new System.Drawing.Point(40, 59);
            this.numericUpDownBufferSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownBufferSize.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownBufferSize.Name = "numericUpDownBufferSize";
            this.numericUpDownBufferSize.Size = new System.Drawing.Size(103, 20);
            this.numericUpDownBufferSize.TabIndex = 6;
            this.numericUpDownBufferSize.ThousandsSeparator = true;
            this.numericUpDownBufferSize.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            // 
            // labelBufferSize
            // 
            this.labelBufferSize.AutoSize = true;
            this.labelBufferSize.Location = new System.Drawing.Point(37, 43);
            this.labelBufferSize.Name = "labelBufferSize";
            this.labelBufferSize.Size = new System.Drawing.Size(92, 13);
            this.labelBufferSize.TabIndex = 7;
            this.labelBufferSize.Text = "Buffer Size (bytes)";
            // 
            // numericUpDownDeadline
            // 
            this.numericUpDownDeadline.Location = new System.Drawing.Point(40, 107);
            this.numericUpDownDeadline.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownDeadline.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownDeadline.Name = "numericUpDownDeadline";
            this.numericUpDownDeadline.Size = new System.Drawing.Size(103, 20);
            this.numericUpDownDeadline.TabIndex = 6;
            this.numericUpDownDeadline.ThousandsSeparator = true;
            this.numericUpDownDeadline.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // labelDeadline
            // 
            this.labelDeadline.AutoSize = true;
            this.labelDeadline.Location = new System.Drawing.Point(37, 91);
            this.labelDeadline.Name = "labelDeadline";
            this.labelDeadline.Size = new System.Drawing.Size(118, 13);
            this.labelDeadline.TabIndex = 7;
            this.labelDeadline.Text = "Packet Deadline (tacts)";
            // 
            // FormNodeProperties
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(182, 180);
            this.Controls.Add(this.labelDeadline);
            this.Controls.Add(this.labelBufferSize);
            this.Controls.Add(this.numericUpDownDeadline);
            this.Controls.Add(this.numericUpDownBufferSize);
            this.Controls.Add(this.checkBoxNodeEnabled);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNodeProperties";
            this.Text = "Node properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxNodeEnabled;
        private System.Windows.Forms.NumericUpDown numericUpDownBufferSize;
        private System.Windows.Forms.Label labelBufferSize;
        private System.Windows.Forms.NumericUpDown numericUpDownDeadline;
        private System.Windows.Forms.Label labelDeadline;
    }
}