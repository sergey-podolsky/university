namespace TravelingSalesman
{
    partial class FormGraph
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
            this.area = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.area.Location = new System.Drawing.Point(0, 0);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(292, 273);
            this.area.TabIndex = 0;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.area_Paint);
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.area);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormGraph";
            this.Text = "Граф";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label area;
    }
}