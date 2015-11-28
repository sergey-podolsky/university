namespace NetworkRouting
{
    partial class FormStatistics
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliveryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataPackets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServicePackets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMessage,
            this.ColumnSize,
            this.ColumnSource,
            this.ColumnTarget,
            this.ColumnMode,
            this.ColumnDeliveryTime,
            this.ColumnDataPackets,
            this.ColumnServicePackets});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(495, 329);
            this.dataGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearStatisticsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(495, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearStatisticsToolStripMenuItem
            // 
            this.clearStatisticsToolStripMenuItem.Name = "clearStatisticsToolStripMenuItem";
            this.clearStatisticsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.clearStatisticsToolStripMenuItem.Text = "Clear statistics";
            this.clearStatisticsToolStripMenuItem.Click += new System.EventHandler(this.clearStatisticsToolStripMenuItem_Click);
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.HeaderText = "Message ID";
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            // 
            // ColumnSize
            // 
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ReadOnly = true;
            // 
            // ColumnSource
            // 
            this.ColumnSource.HeaderText = "Source";
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.ReadOnly = true;
            // 
            // ColumnTarget
            // 
            this.ColumnTarget.HeaderText = "Target";
            this.ColumnTarget.Name = "ColumnTarget";
            this.ColumnTarget.ReadOnly = true;
            // 
            // ColumnMode
            // 
            this.ColumnMode.HeaderText = "Mode";
            this.ColumnMode.Name = "ColumnMode";
            this.ColumnMode.ReadOnly = true;
            // 
            // ColumnDeliveryTime
            // 
            this.ColumnDeliveryTime.HeaderText = "Delivery Time";
            this.ColumnDeliveryTime.Name = "ColumnDeliveryTime";
            this.ColumnDeliveryTime.ReadOnly = true;
            // 
            // ColumnDataPackets
            // 
            this.ColumnDataPackets.HeaderText = "Data Packets";
            this.ColumnDataPackets.Name = "ColumnDataPackets";
            this.ColumnDataPackets.ReadOnly = true;
            // 
            // ColumnServicePackets
            // 
            this.ColumnServicePackets.HeaderText = "Service Packets";
            this.ColumnServicePackets.Name = "ColumnServicePackets";
            this.ColumnServicePackets.ReadOnly = true;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 353);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormStatistics";
            this.Text = "Delivery statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatistics_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearStatisticsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliveryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataPackets;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServicePackets;
    }
}