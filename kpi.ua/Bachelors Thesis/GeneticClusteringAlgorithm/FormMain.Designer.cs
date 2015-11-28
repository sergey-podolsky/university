namespace GeneticClusteringAlgorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clearVertecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.area = new System.Windows.Forms.Label();
            this.labelVertecesPerClick = new System.Windows.Forms.Label();
            this.labelDispersion = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelGeneration = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFitness = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSizes = new System.Windows.Forms.TextBox();
            this.numericUpDownDispersion = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVertecesPerClick = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDispersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertecesPerClick)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearVertecesToolStripMenuItem,
            this.runGAToolStripMenuItem,
            this.stopGAToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // clearVertecesToolStripMenuItem
            // 
            this.clearVertecesToolStripMenuItem.Name = "clearVertecesToolStripMenuItem";
            this.clearVertecesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.clearVertecesToolStripMenuItem.Text = "Clear All";
            this.clearVertecesToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // runGAToolStripMenuItem
            // 
            this.runGAToolStripMenuItem.Name = "runGAToolStripMenuItem";
            this.runGAToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.runGAToolStripMenuItem.Text = "Run GA";
            this.runGAToolStripMenuItem.Click += new System.EventHandler(this.runGAToolStripMenuItem_Click);
            // 
            // stopGAToolStripMenuItem
            // 
            this.stopGAToolStripMenuItem.Enabled = false;
            this.stopGAToolStripMenuItem.Name = "stopGAToolStripMenuItem";
            this.stopGAToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.stopGAToolStripMenuItem.Text = "Stop GA";
            this.stopGAToolStripMenuItem.Click += new System.EventHandler(this.stopGAToolStripMenuItem_Click);
            // 
            // area
            // 
            this.area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.area.BackColor = System.Drawing.Color.White;
            this.area.Cursor = System.Windows.Forms.Cursors.Cross;
            this.area.Location = new System.Drawing.Point(114, 49);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(670, 491);
            this.area.TabIndex = 1;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.area_Paint);
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            // 
            // labelVertecesPerClick
            // 
            this.labelVertecesPerClick.AutoSize = true;
            this.labelVertecesPerClick.Location = new System.Drawing.Point(13, 60);
            this.labelVertecesPerClick.Name = "labelVertecesPerClick";
            this.labelVertecesPerClick.Size = new System.Drawing.Size(82, 13);
            this.labelVertecesPerClick.TabIndex = 2;
            this.labelVertecesPerClick.Text = "Points per click:";
            // 
            // labelDispersion
            // 
            this.labelDispersion.AutoSize = true;
            this.labelDispersion.Location = new System.Drawing.Point(13, 117);
            this.labelDispersion.Name = "labelDispersion";
            this.labelDispersion.Size = new System.Drawing.Size(89, 13);
            this.labelDispersion.TabIndex = 2;
            this.labelDispersion.Text = "Points dispersion:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelGeneration,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelFitness});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Time:";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabelTime.Text = "00:00";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "Generation: ";
            // 
            // toolStripStatusLabelGeneration
            // 
            this.toolStripStatusLabelGeneration.Name = "toolStripStatusLabelGeneration";
            this.toolStripStatusLabelGeneration.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelGeneration.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel3.Text = "Fitness:";
            // 
            // toolStripStatusLabelFitness
            // 
            this.toolStripStatusLabelFitness.Name = "toolStripStatusLabelFitness";
            this.toolStripStatusLabelFitness.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelFitness.Text = "0";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonOpen});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML files|*.xml|MATLAB files|*.dat|All files|*.*";
            this.saveFileDialog.Title = "Save to file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML files|*.xml|MATLAB files|*.dat|All files|*.*";
            this.openFileDialog.Title = "Open from file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cluster sizes:";
            // 
            // textBoxSizes
            // 
            this.textBoxSizes.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GeneticClusteringAlgorithm.Properties.Settings.Default, "ClusterSizes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSizes.Location = new System.Drawing.Point(12, 195);
            this.textBoxSizes.Multiline = true;
            this.textBoxSizes.Name = "textBoxSizes";
            this.textBoxSizes.Size = new System.Drawing.Size(96, 134);
            this.textBoxSizes.TabIndex = 8;
            this.textBoxSizes.Text = global::GeneticClusteringAlgorithm.Properties.Settings.Default.ClusterSizes;
            // 
            // numericUpDownDispersion
            // 
            this.numericUpDownDispersion.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GeneticClusteringAlgorithm.Properties.Settings.Default, "Dispersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownDispersion.DecimalPlaces = 4;
            this.numericUpDownDispersion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownDispersion.Location = new System.Drawing.Point(16, 133);
            this.numericUpDownDispersion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownDispersion.Name = "numericUpDownDispersion";
            this.numericUpDownDispersion.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownDispersion.TabIndex = 3;
            this.numericUpDownDispersion.Value = global::GeneticClusteringAlgorithm.Properties.Settings.Default.Dispersion;
            // 
            // numericUpDownVertecesPerClick
            // 
            this.numericUpDownVertecesPerClick.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GeneticClusteringAlgorithm.Properties.Settings.Default, "PointsPerClick", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownVertecesPerClick.Location = new System.Drawing.Point(16, 76);
            this.numericUpDownVertecesPerClick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownVertecesPerClick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVertecesPerClick.Name = "numericUpDownVertecesPerClick";
            this.numericUpDownVertecesPerClick.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownVertecesPerClick.TabIndex = 3;
            this.numericUpDownVertecesPerClick.Value = global::GeneticClusteringAlgorithm.Properties.Settings.Default.PointsPerClick;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.textBoxSizes);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.numericUpDownDispersion);
            this.Controls.Add(this.labelDispersion);
            this.Controls.Add(this.numericUpDownVertecesPerClick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVertecesPerClick);
            this.Controls.Add(this.area);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.Text = "Graph Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDispersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertecesPerClick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem clearVertecesToolStripMenuItem;
        private System.Windows.Forms.Label area;
        private System.Windows.Forms.Label labelVertecesPerClick;
        private System.Windows.Forms.NumericUpDown numericUpDownVertecesPerClick;
        private System.Windows.Forms.Label labelDispersion;
        private System.Windows.Forms.NumericUpDown numericUpDownDispersion;
        private System.Windows.Forms.ToolStripMenuItem runGAToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem stopGAToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGeneration;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFitness;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TextBox textBoxSizes;
        private System.Windows.Forms.Label label1;

    }
}

