namespace Petri
{
    partial class FormProperties
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
            this.numericUpDownMarkers = new System.Windows.Forms.NumericUpDown();
            this.labelMarkers = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkers)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownMarkers
            // 
            this.numericUpDownMarkers.Location = new System.Drawing.Point(35, 38);
            this.numericUpDownMarkers.Name = "numericUpDownMarkers";
            this.numericUpDownMarkers.Size = new System.Drawing.Size(102, 20);
            this.numericUpDownMarkers.TabIndex = 0;
            // 
            // labelMarkers
            // 
            this.labelMarkers.AutoSize = true;
            this.labelMarkers.Location = new System.Drawing.Point(32, 22);
            this.labelMarkers.Name = "labelMarkers";
            this.labelMarkers.Size = new System.Drawing.Size(105, 13);
            this.labelMarkers.TabIndex = 1;
            this.labelMarkers.Text = "Кількість маркерів:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(49, 123);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 158);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelMarkers);
            this.Controls.Add(this.numericUpDownMarkers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProperties";
            this.Text = "Позиція";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownMarkers;
        private System.Windows.Forms.Label labelMarkers;
        private System.Windows.Forms.Button buttonOk;
    }
}