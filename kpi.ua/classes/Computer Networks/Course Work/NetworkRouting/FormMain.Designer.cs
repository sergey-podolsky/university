namespace NetworkRouting
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.area = new System.Windows.Forms.Label();
            this.contextMenuStripNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showRouteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeDistancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeTransitionCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDeliveryStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripEdge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.edgePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripButtonPointer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendMessages = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripNode.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripEdge.SuspendLayout();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.area.BackColor = System.Drawing.Color.White;
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Location = new System.Drawing.Point(12, 62);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(984, 591);
            this.area.TabIndex = 1;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.area_Paint);
            this.area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.area_MouseMove);
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            this.area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.area_MouseUp);
            // 
            // contextMenuStripNode
            // 
            this.contextMenuStripNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeNodeToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showRouteTableToolStripMenuItem,
            this.nodePropertiesToolStripMenuItem});
            this.contextMenuStripNode.Name = "contextMenuStripNode";
            this.contextMenuStripNode.Size = new System.Drawing.Size(169, 76);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeNodeToolStripMenuItem.Text = "Remove Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(165, 6);
            // 
            // showRouteTableToolStripMenuItem
            // 
            this.showRouteTableToolStripMenuItem.Name = "showRouteTableToolStripMenuItem";
            this.showRouteTableToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showRouteTableToolStripMenuItem.Text = "Show route table";
            this.showRouteTableToolStripMenuItem.Click += new System.EventHandler(this.showRouteTableToolStripMenuItem_Click);
            // 
            // nodePropertiesToolStripMenuItem
            // 
            this.nodePropertiesToolStripMenuItem.Name = "nodePropertiesToolStripMenuItem";
            this.nodePropertiesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nodePropertiesToolStripMenuItem.Text = "Node properties...";
            this.nodePropertiesToolStripMenuItem.Click += new System.EventHandler(this.nodePropertiesToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPointer,
            this.toolStripButtonNode,
            this.toolStripButtonEdge,
            this.toolStripSeparator1,
            this.toolStripButtonPlay,
            this.toolStripButtonStep,
            this.toolStripSeparator2,
            this.toolStripButtonSendMessages,
            this.toolStripSeparator4});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 38);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawGridToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // drawGridToolStripMenuItem
            // 
            this.drawGridToolStripMenuItem.Checked = true;
            this.drawGridToolStripMenuItem.CheckOnClick = true;
            this.drawGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawGridToolStripMenuItem.Name = "drawGridToolStripMenuItem";
            this.drawGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.drawGridToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.drawGridToolStripMenuItem.Text = "Show grid";
            this.drawGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomizeWeightsToolStripMenuItem,
            this.computeDistancesToolStripMenuItem,
            this.computeTransitionCountToolStripMenuItem,
            this.showDeliveryStatisticsToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.actionToolStripMenuItem.Text = "Tools";
            // 
            // randomizeWeightsToolStripMenuItem
            // 
            this.randomizeWeightsToolStripMenuItem.Name = "randomizeWeightsToolStripMenuItem";
            this.randomizeWeightsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.randomizeWeightsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.randomizeWeightsToolStripMenuItem.Text = "Randomize weights";
            this.randomizeWeightsToolStripMenuItem.Click += new System.EventHandler(this.randomizeWeightsToolStripMenuItem_Click);
            // 
            // computeDistancesToolStripMenuItem
            // 
            this.computeDistancesToolStripMenuItem.Name = "computeDistancesToolStripMenuItem";
            this.computeDistancesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.computeDistancesToolStripMenuItem.Text = "Compute distances";
            this.computeDistancesToolStripMenuItem.Click += new System.EventHandler(this.computeDistancesToolStripMenuItem_Click);
            // 
            // computeTransitionCountToolStripMenuItem
            // 
            this.computeTransitionCountToolStripMenuItem.Name = "computeTransitionCountToolStripMenuItem";
            this.computeTransitionCountToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.computeTransitionCountToolStripMenuItem.Text = "Compute transition count";
            this.computeTransitionCountToolStripMenuItem.Click += new System.EventHandler(this.computeTransitionCountToolStripMenuItem_Click);
            // 
            // showDeliveryStatisticsToolStripMenuItem
            // 
            this.showDeliveryStatisticsToolStripMenuItem.Name = "showDeliveryStatisticsToolStripMenuItem";
            this.showDeliveryStatisticsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showDeliveryStatisticsToolStripMenuItem.Text = "Show delivery statistics";
            this.showDeliveryStatisticsToolStripMenuItem.Click += new System.EventHandler(this.showDeliveryStatisticsToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Petri.net";
            this.openFileDialog.Filter = "Networks|*.net|All files|*.*";
            this.openFileDialog.Title = "Відкрити файл";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Networks|*.net|All files|*.*";
            this.saveFileDialog.Title = "Зберегти в файл";
            // 
            // contextMenuStripEdge
            // 
            this.contextMenuStripEdge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeEdgeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.edgePropertiesToolStripMenuItem});
            this.contextMenuStripEdge.Name = "contextMenuStripEdge";
            this.contextMenuStripEdge.Size = new System.Drawing.Size(166, 54);
            // 
            // removeEdgeToolStripMenuItem
            // 
            this.removeEdgeToolStripMenuItem.Name = "removeEdgeToolStripMenuItem";
            this.removeEdgeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeEdgeToolStripMenuItem.Text = "Remove edge";
            this.removeEdgeToolStripMenuItem.Click += new System.EventHandler(this.removeEdgeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 6);
            // 
            // edgePropertiesToolStripMenuItem
            // 
            this.edgePropertiesToolStripMenuItem.Name = "edgePropertiesToolStripMenuItem";
            this.edgePropertiesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.edgePropertiesToolStripMenuItem.Text = "Edge properties...";
            this.edgePropertiesToolStripMenuItem.Click += new System.EventHandler(this.edgePropertiesToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.toolStripButtonStep_Click);
            // 
            // toolStripButtonPointer
            // 
            this.toolStripButtonPointer.Checked = true;
            this.toolStripButtonPointer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonPointer.Image = global::NetworkRouting.Properties.Resources.Cursor;
            this.toolStripButtonPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPointer.Name = "toolStripButtonPointer";
            this.toolStripButtonPointer.Size = new System.Drawing.Size(49, 35);
            this.toolStripButtonPointer.Text = "Pointer";
            this.toolStripButtonPointer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPointer.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonNode
            // 
            this.toolStripButtonNode.Image = global::NetworkRouting.Properties.Resources.Computer1;
            this.toolStripButtonNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNode.Name = "toolStripButtonNode";
            this.toolStripButtonNode.Size = new System.Drawing.Size(40, 35);
            this.toolStripButtonNode.Text = "Node";
            this.toolStripButtonNode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonNode.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonEdge
            // 
            this.toolStripButtonEdge.Image = global::NetworkRouting.Properties.Resources.connect_no_3279_32;
            this.toolStripButtonEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdge.Name = "toolStripButtonEdge";
            this.toolStripButtonEdge.Size = new System.Drawing.Size(37, 35);
            this.toolStripButtonEdge.Text = "Edge";
            this.toolStripButtonEdge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEdge.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.Image = global::NetworkRouting.Properties.Resources.Play;
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(32, 35);
            this.toolStripButtonPlay.Text = "Run";
            this.toolStripButtonPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // toolStripButtonStep
            // 
            this.toolStripButtonStep.Image = global::NetworkRouting.Properties.Resources.Step;
            this.toolStripButtonStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStep.Name = "toolStripButtonStep";
            this.toolStripButtonStep.Size = new System.Drawing.Size(51, 35);
            this.toolStripButtonStep.Text = "+1 Step";
            this.toolStripButtonStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonStep.Click += new System.EventHandler(this.toolStripButtonStep_Click);
            // 
            // toolStripButtonSendMessages
            // 
            this.toolStripButtonSendMessages.Image = global::NetworkRouting.Properties.Resources.Mail_24x24;
            this.toolStripButtonSendMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendMessages.Name = "toolStripButtonSendMessages";
            this.toolStripButtonSendMessages.Size = new System.Drawing.Size(107, 35);
            this.toolStripButtonSendMessages.Text = "Send Messages";
            this.toolStripButtonSendMessages.Click += new System.EventHandler(this.sendMessagesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.area);
            this.Name = "FormMain";
            this.Text = "Network topology designer - Podolsky Sergey KV-64";
            this.contextMenuStripNode.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripEdge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label area;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonPointer;
        private System.Windows.Forms.ToolStripButton toolStripButtonNode;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdge;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGridToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeWeightsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNode;
        private System.Windows.Forms.ToolStripMenuItem computeDistancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeTransitionCountToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEdge;
        private System.Windows.Forms.ToolStripMenuItem removeEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem edgePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRouteTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.ToolStripButton toolStripButtonStep;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem nodePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDeliveryStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendMessages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

