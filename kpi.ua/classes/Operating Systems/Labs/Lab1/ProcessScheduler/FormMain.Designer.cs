namespace ProcessScheduler
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelProcessName = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSuspendTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.labelIterations = new System.Windows.Forms.Label();
            this.labelProcessNumber = new System.Windows.Forms.Label();
            this.numericUpDownIterations = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownProcessNumber = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.labelPackadeTitle = new System.Windows.Forms.Label();
            this.labelPackadePercent = new System.Windows.Forms.Label();
            this.groupBoxTiming = new System.Windows.Forms.GroupBox();
            this.labelInteractivePercent = new System.Windows.Forms.Label();
            this.labelInteractiveTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBoxTiming.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проПрограмуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.Color.White;
            this.textBoxPath.Location = new System.Drawing.Point(108, 41);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(474, 20);
            this.textBoxPath.TabIndex = 3;
            this.textBoxPath.Text = "..\\..\\..\\ProcessModel\\bin\\Debug\\ProcessModel.exe";
            // 
            // labelProcessName
            // 
            this.labelProcessName.AutoSize = true;
            this.labelProcessName.Location = new System.Drawing.Point(10, 44);
            this.labelProcessName.Name = "labelProcessName";
            this.labelProcessName.Size = new System.Drawing.Size(93, 13);
            this.labelProcessName.TabIndex = 4;
            this.labelProcessName.Text = "Модель процесу:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(588, 39);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(34, 23);
            this.buttonBrowse.TabIndex = 5;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "*.exe файли|*.exe|Всі файли|*.*";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(6, 98);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(191, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Додати процес";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProcessName,
            this.ColumnStartTime,
            this.ColumnTerminateTime,
            this.ColumnWorkTime,
            this.ColumnSuspendTime,
            this.ColumnTotalTime});
            this.dataGridView.Location = new System.Drawing.Point(12, 243);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(613, 327);
            this.dataGridView.TabIndex = 7;
            // 
            // ColumnProcessName
            // 
            this.ColumnProcessName.HeaderText = "Номер процесу";
            this.ColumnProcessName.Name = "ColumnProcessName";
            this.ColumnProcessName.ReadOnly = true;
            // 
            // ColumnStartTime
            // 
            this.ColumnStartTime.HeaderText = "Час запуску";
            this.ColumnStartTime.Name = "ColumnStartTime";
            this.ColumnStartTime.ReadOnly = true;
            // 
            // ColumnTerminateTime
            // 
            this.ColumnTerminateTime.HeaderText = "Час завершення";
            this.ColumnTerminateTime.Name = "ColumnTerminateTime";
            this.ColumnTerminateTime.ReadOnly = true;
            // 
            // ColumnWorkTime
            // 
            this.ColumnWorkTime.HeaderText = "Час роботи";
            this.ColumnWorkTime.Name = "ColumnWorkTime";
            this.ColumnWorkTime.ReadOnly = true;
            // 
            // ColumnSuspendTime
            // 
            this.ColumnSuspendTime.HeaderText = "Час очікування";
            this.ColumnSuspendTime.Name = "ColumnSuspendTime";
            this.ColumnSuspendTime.ReadOnly = true;
            // 
            // ColumnTotalTime
            // 
            this.ColumnTotalTime.HeaderText = "Загальний час";
            this.ColumnTotalTime.Name = "ColumnTotalTime";
            this.ColumnTotalTime.ReadOnly = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(497, 576);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(128, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Очистити таблицю";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.labelIterations);
            this.groupBoxAdd.Controls.Add(this.labelProcessNumber);
            this.groupBoxAdd.Controls.Add(this.numericUpDownIterations);
            this.groupBoxAdd.Controls.Add(this.buttonAdd);
            this.groupBoxAdd.Controls.Add(this.numericUpDownProcessNumber);
            this.groupBoxAdd.Controls.Add(this.comboBoxMode);
            this.groupBoxAdd.Location = new System.Drawing.Point(423, 106);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(203, 131);
            this.groupBoxAdd.TabIndex = 9;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Додати до черги новий процес";
            // 
            // labelIterations
            // 
            this.labelIterations.AutoSize = true;
            this.labelIterations.Location = new System.Drawing.Point(20, 74);
            this.labelIterations.Name = "labelIterations";
            this.labelIterations.Size = new System.Drawing.Size(98, 13);
            this.labelIterations.TabIndex = 2;
            this.labelIterations.Text = "Кількість ітерацій:";
            // 
            // labelProcessNumber
            // 
            this.labelProcessNumber.AutoSize = true;
            this.labelProcessNumber.Location = new System.Drawing.Point(30, 48);
            this.labelProcessNumber.Name = "labelProcessNumber";
            this.labelProcessNumber.Size = new System.Drawing.Size(88, 13);
            this.labelProcessNumber.TabIndex = 2;
            this.labelProcessNumber.Text = "Номер процесу:";
            // 
            // numericUpDownIterations
            // 
            this.numericUpDownIterations.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownIterations.Location = new System.Drawing.Point(121, 72);
            this.numericUpDownIterations.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.numericUpDownIterations.Name = "numericUpDownIterations";
            this.numericUpDownIterations.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownIterations.TabIndex = 1;
            this.numericUpDownIterations.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            // 
            // numericUpDownProcessNumber
            // 
            this.numericUpDownProcessNumber.Location = new System.Drawing.Point(121, 46);
            this.numericUpDownProcessNumber.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.numericUpDownProcessNumber.Name = "numericUpDownProcessNumber";
            this.numericUpDownProcessNumber.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownProcessNumber.TabIndex = 1;
            this.numericUpDownProcessNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Інтерактивний процес (RR)",
            "Пакетний процес (FCFS)",
            "Пакетний процес (LIFO)"});
            this.comboBoxMode.Location = new System.Drawing.Point(6, 19);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(191, 21);
            this.comboBoxMode.TabIndex = 0;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(10, 74);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(92, 13);
            this.labelInterval.TabIndex = 10;
            this.labelInterval.Text = "Квант часу (сек):";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.DecimalPlaces = 1;
            this.numericUpDownInterval.Location = new System.Drawing.Point(108, 72);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownInterval.TabIndex = 11;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(6, 19);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(390, 45);
            this.trackBar.TabIndex = 12;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 80;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // labelPackadeTitle
            // 
            this.labelPackadeTitle.AutoSize = true;
            this.labelPackadeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPackadeTitle.Location = new System.Drawing.Point(6, 51);
            this.labelPackadeTitle.Name = "labelPackadeTitle";
            this.labelPackadeTitle.Size = new System.Drawing.Size(103, 13);
            this.labelPackadeTitle.TabIndex = 13;
            this.labelPackadeTitle.Text = "Фонові процеси";
            // 
            // labelPackadePercent
            // 
            this.labelPackadePercent.AutoSize = true;
            this.labelPackadePercent.Location = new System.Drawing.Point(9, 71);
            this.labelPackadePercent.Name = "labelPackadePercent";
            this.labelPackadePercent.Size = new System.Drawing.Size(35, 13);
            this.labelPackadePercent.TabIndex = 15;
            this.labelPackadePercent.Text = "label3";
            // 
            // groupBoxTiming
            // 
            this.groupBoxTiming.Controls.Add(this.labelInteractivePercent);
            this.groupBoxTiming.Controls.Add(this.labelInteractiveTitle);
            this.groupBoxTiming.Controls.Add(this.labelPackadeTitle);
            this.groupBoxTiming.Controls.Add(this.labelPackadePercent);
            this.groupBoxTiming.Controls.Add(this.trackBar);
            this.groupBoxTiming.Location = new System.Drawing.Point(13, 106);
            this.groupBoxTiming.Name = "groupBoxTiming";
            this.groupBoxTiming.Size = new System.Drawing.Size(404, 131);
            this.groupBoxTiming.TabIndex = 17;
            this.groupBoxTiming.TabStop = false;
            this.groupBoxTiming.Text = "Розподіл часу";
            // 
            // labelInteractivePercent
            // 
            this.labelInteractivePercent.AutoSize = true;
            this.labelInteractivePercent.Location = new System.Drawing.Point(264, 71);
            this.labelInteractivePercent.Name = "labelInteractivePercent";
            this.labelInteractivePercent.Size = new System.Drawing.Size(35, 13);
            this.labelInteractivePercent.TabIndex = 18;
            this.labelInteractivePercent.Text = "label4";
            // 
            // labelInteractiveTitle
            // 
            this.labelInteractiveTitle.AutoSize = true;
            this.labelInteractiveTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInteractiveTitle.Location = new System.Drawing.Point(261, 51);
            this.labelInteractiveTitle.Name = "labelInteractiveTitle";
            this.labelInteractiveTitle.Size = new System.Drawing.Size(135, 13);
            this.labelInteractiveTitle.TabIndex = 17;
            this.labelInteractiveTitle.Text = "Інтерактивні процеси";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 607);
            this.Controls.Add(this.groupBoxTiming);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.groupBoxAdd);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelProcessName);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Планувальник процесів - багаторівневі черги (2 рівні)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBoxTiming.ResumeLayout(false);
            this.groupBoxTiming.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelProcessName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSuspendTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalTime;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.NumericUpDown numericUpDownProcessNumber;
        private System.Windows.Forms.Label labelProcessNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownIterations;
        private System.Windows.Forms.Label labelIterations;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label labelPackadeTitle;
        private System.Windows.Forms.Label labelPackadePercent;
        private System.Windows.Forms.GroupBox groupBoxTiming;
        private System.Windows.Forms.Label labelInteractivePercent;
        private System.Windows.Forms.Label labelInteractiveTitle;
    }
}

