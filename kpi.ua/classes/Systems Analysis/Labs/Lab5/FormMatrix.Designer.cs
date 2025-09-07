namespace Petri
{
    partial class FormMatrix
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxDq = new System.Windows.Forms.ListBox();
            this.listBoxDi = new System.Windows.Forms.ListBox();
            this.listBoxM = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.listBoxDq, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxDi, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxM, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(568, 249);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // listBoxDq
            // 
            this.listBoxDq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDq.FormattingEnabled = true;
            this.listBoxDq.HorizontalScrollbar = true;
            this.listBoxDq.Location = new System.Drawing.Point(288, 6);
            this.listBoxDq.Name = "listBoxDq";
            this.listBoxDq.Size = new System.Drawing.Size(274, 160);
            this.listBoxDq.TabIndex = 3;
            // 
            // listBoxDi
            // 
            this.listBoxDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDi.FormattingEnabled = true;
            this.listBoxDi.HorizontalScrollbar = true;
            this.listBoxDi.Location = new System.Drawing.Point(6, 6);
            this.listBoxDi.Name = "listBoxDi";
            this.listBoxDi.Size = new System.Drawing.Size(273, 160);
            this.listBoxDi.TabIndex = 1;
            // 
            // listBoxM
            // 
            this.listBoxM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxM.FormattingEnabled = true;
            this.listBoxM.HorizontalScrollbar = true;
            this.listBoxM.Location = new System.Drawing.Point(6, 185);
            this.listBoxM.Name = "listBoxM";
            this.listBoxM.Size = new System.Drawing.Size(273, 56);
            this.listBoxM.TabIndex = 2;
            // 
            // FormMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormMatrix";
            this.Text = "Матриці мережі";
            this.Load += new System.EventHandler(this.FormMatrix_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox listBoxDi;
        private System.Windows.Forms.ListBox listBoxDq;
        private System.Windows.Forms.ListBox listBoxM;
    }
}