namespace Notepad
{
    partial class FormFind
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelFindWhat = new System.Windows.Forms.Label();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.labelMatches = new System.Windows.Forms.Label();
            this.buttonFindAll = new System.Windows.Forms.Button();
            this.checkBoxWholeWords = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(74, 6);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(186, 20);
            this.textBox.TabIndex = 0;
            // 
            // labelFindWhat
            // 
            this.labelFindWhat.AutoSize = true;
            this.labelFindWhat.Location = new System.Drawing.Point(12, 9);
            this.labelFindWhat.Name = "labelFindWhat";
            this.labelFindWhat.Size = new System.Drawing.Size(56, 13);
            this.labelFindWhat.TabIndex = 2;
            this.labelFindWhat.Text = "Find what:";
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.AutoSize = true;
            this.checkBoxMatchCase.Location = new System.Drawing.Point(12, 55);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(83, 17);
            this.checkBoxMatchCase.TabIndex = 3;
            this.checkBoxMatchCase.Text = "Match Case";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // labelMatches
            // 
            this.labelMatches.AutoSize = true;
            this.labelMatches.ForeColor = System.Drawing.Color.DarkRed;
            this.labelMatches.Location = new System.Drawing.Point(71, 29);
            this.labelMatches.Name = "labelMatches";
            this.labelMatches.Size = new System.Drawing.Size(38, 13);
            this.labelMatches.TabIndex = 5;
            this.labelMatches.Text = "Ready";
            // 
            // buttonFindAll
            // 
            this.buttonFindAll.Location = new System.Drawing.Point(266, 4);
            this.buttonFindAll.Name = "buttonFindAll";
            this.buttonFindAll.Size = new System.Drawing.Size(74, 23);
            this.buttonFindAll.TabIndex = 6;
            this.buttonFindAll.Text = "Find All";
            this.buttonFindAll.UseVisualStyleBackColor = true;
            this.buttonFindAll.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // checkBoxWholeWords
            // 
            this.checkBoxWholeWords.AutoSize = true;
            this.checkBoxWholeWords.Location = new System.Drawing.Point(101, 55);
            this.checkBoxWholeWords.Name = "checkBoxWholeWords";
            this.checkBoxWholeWords.Size = new System.Drawing.Size(88, 17);
            this.checkBoxWholeWords.TabIndex = 4;
            this.checkBoxWholeWords.Text = "Whole words";
            this.checkBoxWholeWords.UseVisualStyleBackColor = true;
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 84);
            this.Controls.Add(this.buttonFindAll);
            this.Controls.Add(this.labelMatches);
            this.Controls.Add(this.checkBoxWholeWords);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.labelFindWhat);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find";
            this.VisibleChanged += new System.EventHandler(this.FormFind_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFind_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFind_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelFindWhat;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.Label labelMatches;
        private System.Windows.Forms.Button buttonFindAll;
        private System.Windows.Forms.CheckBox checkBoxWholeWords;
    }
}