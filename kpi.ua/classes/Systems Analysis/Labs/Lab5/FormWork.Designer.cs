namespace Petri
{
    partial class FormWork
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
            this.textBoxTact = new System.Windows.Forms.TextBox();
            this.buttonTact = new System.Windows.Forms.Button();
            this.labeltact = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTact
            // 
            this.textBoxTact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTact.Location = new System.Drawing.Point(355, 359);
            this.textBoxTact.Name = "textBoxTact";
            this.textBoxTact.Size = new System.Drawing.Size(46, 20);
            this.textBoxTact.TabIndex = 8;
            this.textBoxTact.Text = "0";
            // 
            // buttonTact
            // 
            this.buttonTact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTact.Location = new System.Drawing.Point(407, 357);
            this.buttonTact.Name = "buttonTact";
            this.buttonTact.Size = new System.Drawing.Size(37, 23);
            this.buttonTact.TabIndex = 7;
            this.buttonTact.Text = "+1";
            this.buttonTact.UseVisualStyleBackColor = true;
            this.buttonTact.Click += new System.EventHandler(this.buttonTact_Click);
            // 
            // labeltact
            // 
            this.labeltact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labeltact.AutoSize = true;
            this.labeltact.Location = new System.Drawing.Point(275, 362);
            this.labeltact.Name = "labeltact";
            this.labeltact.Size = new System.Drawing.Size(74, 13);
            this.labeltact.TabIndex = 6;
            this.labeltact.Text = "Номер такту:";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Location = new System.Drawing.Point(13, 356);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(124, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Вихідний стан";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column5});
            this.dataGridView.Location = new System.Drawing.Point(13, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(431, 338);
            this.dataGridView.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Розмітка";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Вектор";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Переходи";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // FormWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 392);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxTact);
            this.Controls.Add(this.buttonTact);
            this.Controls.Add(this.labeltact);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormWork";
            this.Text = "Марковський граф";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWork_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTact;
        private System.Windows.Forms.Button buttonTact;
        private System.Windows.Forms.Label labeltact;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}