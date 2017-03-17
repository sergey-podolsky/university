namespace MemoryMapper
{
    partial class FormMemoryMapper
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
            this.groupBoxAddSection = new System.Windows.Forms.GroupBox();
            this.buttonAddSection = new System.Windows.Forms.Button();
            this.numericUpDownSectionNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSectionSize = new System.Windows.Forms.NumericUpDown();
            this.labelSectionNumber = new System.Windows.Forms.Label();
            this.labelSectionSize = new System.Windows.Forms.Label();
            this.numericUpDownSectionOffset = new System.Windows.Forms.NumericUpDown();
            this.labelSectionOffset = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.програмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезапускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.area = new System.Windows.Forms.Label();
            this.groupBoxAddProcess = new System.Windows.Forms.GroupBox();
            this.buttonAddProcess = new System.Windows.Forms.Button();
            this.numericUpDownProcessNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownProcessSize = new System.Windows.Forms.NumericUpDown();
            this.labelProcessNumber = new System.Windows.Forms.Label();
            this.labelProcessSize = new System.Windows.Forms.Label();
            this.dataGridViewSections = new System.Windows.Forms.DataGridView();
            this.ColumnSectionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSectionSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoryUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewQueue = new System.Windows.Forms.DataGridView();
            this.ColumnProcessNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSections = new System.Windows.Forms.Label();
            this.labelQueue = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelMemory = new System.Windows.Forms.Label();
            this.textBoxMemory = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxAddSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionOffset)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxAddProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAddSection
            // 
            this.groupBoxAddSection.Controls.Add(this.buttonAddSection);
            this.groupBoxAddSection.Controls.Add(this.numericUpDownSectionNumber);
            this.groupBoxAddSection.Controls.Add(this.numericUpDownSectionSize);
            this.groupBoxAddSection.Controls.Add(this.labelSectionNumber);
            this.groupBoxAddSection.Controls.Add(this.labelSectionSize);
            this.groupBoxAddSection.Controls.Add(this.numericUpDownSectionOffset);
            this.groupBoxAddSection.Controls.Add(this.labelSectionOffset);
            this.groupBoxAddSection.Location = new System.Drawing.Point(12, 27);
            this.groupBoxAddSection.Name = "groupBoxAddSection";
            this.groupBoxAddSection.Size = new System.Drawing.Size(230, 131);
            this.groupBoxAddSection.TabIndex = 0;
            this.groupBoxAddSection.TabStop = false;
            this.groupBoxAddSection.Text = "Додати новий розділ";
            // 
            // buttonAddSection
            // 
            this.buttonAddSection.Location = new System.Drawing.Point(122, 98);
            this.buttonAddSection.Name = "buttonAddSection";
            this.buttonAddSection.Size = new System.Drawing.Size(97, 23);
            this.buttonAddSection.TabIndex = 2;
            this.buttonAddSection.Text = "Додати розділ";
            this.buttonAddSection.UseVisualStyleBackColor = true;
            this.buttonAddSection.Click += new System.EventHandler(this.buttonAddSection_Click);
            // 
            // numericUpDownSectionNumber
            // 
            this.numericUpDownSectionNumber.Enabled = false;
            this.numericUpDownSectionNumber.Location = new System.Drawing.Point(122, 19);
            this.numericUpDownSectionNumber.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSectionNumber.Name = "numericUpDownSectionNumber";
            this.numericUpDownSectionNumber.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownSectionNumber.TabIndex = 1;
            this.numericUpDownSectionNumber.ThousandsSeparator = true;
            // 
            // numericUpDownSectionSize
            // 
            this.numericUpDownSectionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownSectionSize.Location = new System.Drawing.Point(122, 71);
            this.numericUpDownSectionSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownSectionSize.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownSectionSize.Name = "numericUpDownSectionSize";
            this.numericUpDownSectionSize.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownSectionSize.TabIndex = 1;
            this.numericUpDownSectionSize.ThousandsSeparator = true;
            this.numericUpDownSectionSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // labelSectionNumber
            // 
            this.labelSectionNumber.AutoSize = true;
            this.labelSectionNumber.Location = new System.Drawing.Point(16, 21);
            this.labelSectionNumber.Name = "labelSectionNumber";
            this.labelSectionNumber.Size = new System.Drawing.Size(84, 13);
            this.labelSectionNumber.TabIndex = 0;
            this.labelSectionNumber.Text = "Номер розділу:";
            // 
            // labelSectionSize
            // 
            this.labelSectionSize.AutoSize = true;
            this.labelSectionSize.Location = new System.Drawing.Point(16, 73);
            this.labelSectionSize.Name = "labelSectionSize";
            this.labelSectionSize.Size = new System.Drawing.Size(85, 13);
            this.labelSectionSize.TabIndex = 0;
            this.labelSectionSize.Text = "Розмір розділу:";
            // 
            // numericUpDownSectionOffset
            // 
            this.numericUpDownSectionOffset.Enabled = false;
            this.numericUpDownSectionOffset.Location = new System.Drawing.Point(122, 45);
            this.numericUpDownSectionOffset.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSectionOffset.Name = "numericUpDownSectionOffset";
            this.numericUpDownSectionOffset.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownSectionOffset.TabIndex = 1;
            this.numericUpDownSectionOffset.ThousandsSeparator = true;
            // 
            // labelSectionOffset
            // 
            this.labelSectionOffset.AutoSize = true;
            this.labelSectionOffset.Location = new System.Drawing.Point(16, 47);
            this.labelSectionOffset.Name = "labelSectionOffset";
            this.labelSectionOffset.Size = new System.Drawing.Size(100, 13);
            this.labelSectionOffset.TabIndex = 0;
            this.labelSectionOffset.Text = "Зміщення розділу:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.програмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // програмаToolStripMenuItem
            // 
            this.програмаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перезапускToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.програмаToolStripMenuItem.Name = "програмаToolStripMenuItem";
            this.програмаToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.програмаToolStripMenuItem.Text = "Програма";
            // 
            // перезапускToolStripMenuItem
            // 
            this.перезапускToolStripMenuItem.Name = "перезапускToolStripMenuItem";
            this.перезапускToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.перезапускToolStripMenuItem.Text = "Перезапуск";
            this.перезапускToolStripMenuItem.Click += new System.EventHandler(this.перезапускToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // area
            // 
            this.area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.area.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.area.Cursor = System.Windows.Forms.Cursors.Hand;
            this.area.Location = new System.Drawing.Point(480, 27);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(300, 453);
            this.area.TabIndex = 2;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.labelArea_Paint);
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            // 
            // groupBoxAddProcess
            // 
            this.groupBoxAddProcess.Controls.Add(this.buttonAddProcess);
            this.groupBoxAddProcess.Controls.Add(this.numericUpDownProcessNumber);
            this.groupBoxAddProcess.Controls.Add(this.numericUpDownProcessSize);
            this.groupBoxAddProcess.Controls.Add(this.labelProcessNumber);
            this.groupBoxAddProcess.Controls.Add(this.labelProcessSize);
            this.groupBoxAddProcess.Location = new System.Drawing.Point(248, 27);
            this.groupBoxAddProcess.Name = "groupBoxAddProcess";
            this.groupBoxAddProcess.Size = new System.Drawing.Size(230, 131);
            this.groupBoxAddProcess.TabIndex = 0;
            this.groupBoxAddProcess.TabStop = false;
            this.groupBoxAddProcess.Text = "Додати новий процес";
            // 
            // buttonAddProcess
            // 
            this.buttonAddProcess.Location = new System.Drawing.Point(122, 98);
            this.buttonAddProcess.Name = "buttonAddProcess";
            this.buttonAddProcess.Size = new System.Drawing.Size(97, 23);
            this.buttonAddProcess.TabIndex = 2;
            this.buttonAddProcess.Text = "Додати процес";
            this.buttonAddProcess.UseVisualStyleBackColor = true;
            this.buttonAddProcess.Click += new System.EventHandler(this.buttonAddProcess_Click);
            // 
            // numericUpDownProcessNumber
            // 
            this.numericUpDownProcessNumber.Enabled = false;
            this.numericUpDownProcessNumber.Location = new System.Drawing.Point(122, 19);
            this.numericUpDownProcessNumber.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownProcessNumber.Name = "numericUpDownProcessNumber";
            this.numericUpDownProcessNumber.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownProcessNumber.TabIndex = 1;
            this.numericUpDownProcessNumber.ThousandsSeparator = true;
            // 
            // numericUpDownProcessSize
            // 
            this.numericUpDownProcessSize.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownProcessSize.Location = new System.Drawing.Point(122, 45);
            this.numericUpDownProcessSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownProcessSize.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownProcessSize.Name = "numericUpDownProcessSize";
            this.numericUpDownProcessSize.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownProcessSize.TabIndex = 1;
            this.numericUpDownProcessSize.ThousandsSeparator = true;
            this.numericUpDownProcessSize.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // labelProcessNumber
            // 
            this.labelProcessNumber.AutoSize = true;
            this.labelProcessNumber.Location = new System.Drawing.Point(16, 21);
            this.labelProcessNumber.Name = "labelProcessNumber";
            this.labelProcessNumber.Size = new System.Drawing.Size(88, 13);
            this.labelProcessNumber.TabIndex = 0;
            this.labelProcessNumber.Text = "Номер процесу:";
            // 
            // labelProcessSize
            // 
            this.labelProcessSize.AutoSize = true;
            this.labelProcessSize.Location = new System.Drawing.Point(16, 47);
            this.labelProcessSize.Name = "labelProcessSize";
            this.labelProcessSize.Size = new System.Drawing.Size(83, 13);
            this.labelProcessSize.TabIndex = 0;
            this.labelProcessSize.Text = "Розмір пам\'яті:";
            // 
            // dataGridViewSections
            // 
            this.dataGridViewSections.AllowUserToAddRows = false;
            this.dataGridViewSections.AllowUserToDeleteRows = false;
            this.dataGridViewSections.AllowUserToResizeColumns = false;
            this.dataGridViewSections.AllowUserToResizeRows = false;
            this.dataGridViewSections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSectionNumber,
            this.ColumnOffset,
            this.ColumnSectionSize,
            this.ColumnProcess,
            this.ColumnMemoryUsed});
            this.dataGridViewSections.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSections.Location = new System.Drawing.Point(12, 208);
            this.dataGridViewSections.MultiSelect = false;
            this.dataGridViewSections.Name = "dataGridViewSections";
            this.dataGridViewSections.ReadOnly = true;
            this.dataGridViewSections.RowHeadersVisible = false;
            this.dataGridViewSections.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSections.Size = new System.Drawing.Size(307, 272);
            this.dataGridViewSections.TabIndex = 3;
            this.dataGridViewSections.SelectionChanged += new System.EventHandler(this.dataGridViewSections_SelectionChanged);
            // 
            // ColumnSectionNumber
            // 
            this.ColumnSectionNumber.HeaderText = "Номер";
            this.ColumnSectionNumber.Name = "ColumnSectionNumber";
            this.ColumnSectionNumber.ReadOnly = true;
            // 
            // ColumnOffset
            // 
            this.ColumnOffset.HeaderText = "Зміщення";
            this.ColumnOffset.Name = "ColumnOffset";
            this.ColumnOffset.ReadOnly = true;
            // 
            // ColumnSectionSize
            // 
            this.ColumnSectionSize.HeaderText = "Розмір";
            this.ColumnSectionSize.Name = "ColumnSectionSize";
            this.ColumnSectionSize.ReadOnly = true;
            // 
            // ColumnProcess
            // 
            this.ColumnProcess.HeaderText = "Процес";
            this.ColumnProcess.Name = "ColumnProcess";
            this.ColumnProcess.ReadOnly = true;
            // 
            // ColumnMemoryUsed
            // 
            this.ColumnMemoryUsed.HeaderText = "Зайнято";
            this.ColumnMemoryUsed.Name = "ColumnMemoryUsed";
            this.ColumnMemoryUsed.ReadOnly = true;
            // 
            // dataGridViewQueue
            // 
            this.dataGridViewQueue.AllowUserToAddRows = false;
            this.dataGridViewQueue.AllowUserToDeleteRows = false;
            this.dataGridViewQueue.AllowUserToResizeColumns = false;
            this.dataGridViewQueue.AllowUserToResizeRows = false;
            this.dataGridViewQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProcessNumber,
            this.ColumnProcessSize});
            this.dataGridViewQueue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewQueue.Location = new System.Drawing.Point(325, 208);
            this.dataGridViewQueue.MultiSelect = false;
            this.dataGridViewQueue.Name = "dataGridViewQueue";
            this.dataGridViewQueue.ReadOnly = true;
            this.dataGridViewQueue.RowHeadersVisible = false;
            this.dataGridViewQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewQueue.Size = new System.Drawing.Size(149, 272);
            this.dataGridViewQueue.TabIndex = 4;
            // 
            // ColumnProcessNumber
            // 
            this.ColumnProcessNumber.HeaderText = "Номер";
            this.ColumnProcessNumber.Name = "ColumnProcessNumber";
            this.ColumnProcessNumber.ReadOnly = true;
            // 
            // ColumnProcessSize
            // 
            this.ColumnProcessSize.HeaderText = "Розмір";
            this.ColumnProcessSize.Name = "ColumnProcessSize";
            this.ColumnProcessSize.ReadOnly = true;
            // 
            // labelSections
            // 
            this.labelSections.AutoSize = true;
            this.labelSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSections.ForeColor = System.Drawing.Color.Brown;
            this.labelSections.Location = new System.Drawing.Point(12, 185);
            this.labelSections.Name = "labelSections";
            this.labelSections.Size = new System.Drawing.Size(143, 20);
            this.labelSections.TabIndex = 5;
            this.labelSections.Text = "Список розділів";
            // 
            // labelQueue
            // 
            this.labelQueue.AutoSize = true;
            this.labelQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQueue.ForeColor = System.Drawing.Color.Brown;
            this.labelQueue.Location = new System.Drawing.Point(321, 185);
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.Size = new System.Drawing.Size(138, 20);
            this.labelQueue.TabIndex = 5;
            this.labelQueue.Text = "Черга процесів";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(12, 486);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(107, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Звільнити";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelMemory
            // 
            this.labelMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMemory.AutoSize = true;
            this.labelMemory.Location = new System.Drawing.Point(610, 486);
            this.labelMemory.Name = "labelMemory";
            this.labelMemory.Size = new System.Drawing.Size(83, 13);
            this.labelMemory.TabIndex = 7;
            this.labelMemory.Text = "Розмір пам\'яті:";
            // 
            // textBoxMemory
            // 
            this.textBoxMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMemory.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMemory.Location = new System.Drawing.Point(699, 483);
            this.textBoxMemory.Name = "textBoxMemory";
            this.textBoxMemory.ReadOnly = true;
            this.textBoxMemory.Size = new System.Drawing.Size(81, 20);
            this.textBoxMemory.TabIndex = 8;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Поточна адреса";
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            // 
            // FormMemoryMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 523);
            this.Controls.Add(this.textBoxMemory);
            this.Controls.Add(this.labelMemory);
            this.Controls.Add(this.dataGridViewSections);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelSections);
            this.Controls.Add(this.labelQueue);
            this.Controls.Add(this.groupBoxAddSection);
            this.Controls.Add(this.dataGridViewQueue);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBoxAddProcess);
            this.Controls.Add(this.area);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 550);
            this.Name = "FormMemoryMapper";
            this.Text = "Подольський Сергій КВ-64 \"Модель правління пам\'яттю з фіксованими розділами\"";
            this.groupBoxAddSection.ResumeLayout(false);
            this.groupBoxAddSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectionOffset)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxAddProcess.ResumeLayout(false);
            this.groupBoxAddProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAddSection;
        private System.Windows.Forms.NumericUpDown numericUpDownSectionOffset;
        private System.Windows.Forms.Label labelSectionOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownSectionSize;
        private System.Windows.Forms.Label labelSectionSize;
        private System.Windows.Forms.NumericUpDown numericUpDownSectionNumber;
        private System.Windows.Forms.Label labelSectionNumber;
        private System.Windows.Forms.Button buttonAddSection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem програмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезапускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.Label area;
        private System.Windows.Forms.GroupBox groupBoxAddProcess;
        private System.Windows.Forms.Button buttonAddProcess;
        private System.Windows.Forms.NumericUpDown numericUpDownProcessNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownProcessSize;
        private System.Windows.Forms.Label labelProcessNumber;
        private System.Windows.Forms.Label labelProcessSize;
        private System.Windows.Forms.DataGridView dataGridViewSections;
        private System.Windows.Forms.DataGridView dataGridViewQueue;
        private System.Windows.Forms.Label labelSections;
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSectionSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoryUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessSize;
        private System.Windows.Forms.Label labelMemory;
        private System.Windows.Forms.TextBox textBoxMemory;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

