namespace Petri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.area = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаМережаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.зберегтиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.завантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сіткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.малюватиСіткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицыСетиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.марковськийГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.марковськийГрафToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.марковськийГрафToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPointer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlace = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTransition = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArc = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.властивостіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
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
            this.area.Size = new System.Drawing.Size(768, 502);
            this.area.TabIndex = 0;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.area_Paint);
            this.area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.area_MouseMove);
            this.area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.area_MouseDown);
            this.area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.area_MouseUp);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сіткаToolStripMenuItem,
            this.матрицыСетиToolStripMenuItem,
            this.марковськийГрафToolStripMenuItem,
            this.марковськийГрафToolStripMenuItem1,
            this.марковськийГрафToolStripMenuItem2,
            this.проПрограмуToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаМережаToolStripMenuItem,
            this.toolStripMenuItem1,
            this.зберегтиToolStripMenuItem1,
            this.зберегтиToolStripMenuItem,
            this.toolStripMenuItem2,
            this.завантажитиToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            // 
            // новаМережаToolStripMenuItem
            // 
            this.новаМережаToolStripMenuItem.Name = "новаМережаToolStripMenuItem";
            this.новаМережаToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.новаМережаToolStripMenuItem.Text = "Нова мережа";
            this.новаМережаToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.новаМережаToolStripMenuItem.Click += new System.EventHandler(this.новаМережаToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // зберегтиToolStripMenuItem1
            // 
            this.зберегтиToolStripMenuItem1.Name = "зберегтиToolStripMenuItem1";
            this.зберегтиToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.зберегтиToolStripMenuItem1.Text = "Зберегти";
            this.зберегтиToolStripMenuItem1.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.зберегтиToolStripMenuItem.Text = "Зберегти як...";
            this.зберегтиToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиЯкToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
            // 
            // завантажитиToolStripMenuItem
            // 
            this.завантажитиToolStripMenuItem.Name = "завантажитиToolStripMenuItem";
            this.завантажитиToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.завантажитиToolStripMenuItem.Text = "Завантажити";
            this.завантажитиToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.завантажитиToolStripMenuItem.Click += new System.EventHandler(this.завантажитиToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // сіткаToolStripMenuItem
            // 
            this.сіткаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.малюватиСіткуToolStripMenuItem});
            this.сіткаToolStripMenuItem.Name = "сіткаToolStripMenuItem";
            this.сіткаToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.сіткаToolStripMenuItem.Text = "Сітка";
            // 
            // малюватиСіткуToolStripMenuItem
            // 
            this.малюватиСіткуToolStripMenuItem.Checked = true;
            this.малюватиСіткуToolStripMenuItem.CheckOnClick = true;
            this.малюватиСіткуToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.малюватиСіткуToolStripMenuItem.Name = "малюватиСіткуToolStripMenuItem";
            this.малюватиСіткуToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.малюватиСіткуToolStripMenuItem.Text = "Малювати сітку";
            this.малюватиСіткуToolStripMenuItem.Click += new System.EventHandler(this.малюватиСіткуToolStripMenuItem_Click);
            // 
            // матрицыСетиToolStripMenuItem
            // 
            this.матрицыСетиToolStripMenuItem.Name = "матрицыСетиToolStripMenuItem";
            this.матрицыСетиToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.матрицыСетиToolStripMenuItem.Text = "Матриці мережі";
            this.матрицыСетиToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.матрицыСетиToolStripMenuItem.Click += new System.EventHandler(this.матрицыСетиToolStripMenuItem_Click);
            // 
            // марковськийГрафToolStripMenuItem
            // 
            this.марковськийГрафToolStripMenuItem.Name = "марковськийГрафToolStripMenuItem";
            this.марковськийГрафToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.марковськийГрафToolStripMenuItem.Text = "Робота мережі";
            this.марковськийГрафToolStripMenuItem.Click += new System.EventHandler(this.роботаМережіToolStripMenuItem_Click);
            // 
            // марковськийГрафToolStripMenuItem1
            // 
            this.марковськийГрафToolStripMenuItem1.Name = "марковськийГрафToolStripMenuItem1";
            this.марковськийГрафToolStripMenuItem1.Size = new System.Drawing.Size(124, 20);
            this.марковськийГрафToolStripMenuItem1.Text = "Дерево досяжності";
            this.марковськийГрафToolStripMenuItem1.Click += new System.EventHandler(this.марковськийГрафToolStripMenuItem1_Click);
            // 
            // марковськийГрафToolStripMenuItem2
            // 
            this.марковськийГрафToolStripMenuItem2.Name = "марковськийГрафToolStripMenuItem2";
            this.марковськийГрафToolStripMenuItem2.Size = new System.Drawing.Size(124, 20);
            this.марковськийГрафToolStripMenuItem2.Text = "Марковський граф";
            this.марковськийГрафToolStripMenuItem2.Click += new System.EventHandler(this.марковськийГрафToolStripMenuItem2_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPointer,
            this.toolStripButtonPlace,
            this.toolStripButtonTransition,
            this.toolStripButtonArc});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(792, 38);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            // 
            // toolStripButtonPointer
            // 
            this.toolStripButtonPointer.Checked = true;
            this.toolStripButtonPointer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonPointer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPointer.Image")));
            this.toolStripButtonPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPointer.Name = "toolStripButtonPointer";
            this.toolStripButtonPointer.Size = new System.Drawing.Size(64, 35);
            this.toolStripButtonPointer.Text = "Вказівник";
            this.toolStripButtonPointer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPointer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.toolStripButtonPointer.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonPlace
            // 
            this.toolStripButtonPlace.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlace.Image")));
            this.toolStripButtonPlace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlace.Name = "toolStripButtonPlace";
            this.toolStripButtonPlace.Size = new System.Drawing.Size(55, 35);
            this.toolStripButtonPlace.Text = "Позиція";
            this.toolStripButtonPlace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPlace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.toolStripButtonPlace.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonTransition
            // 
            this.toolStripButtonTransition.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTransition.Image")));
            this.toolStripButtonTransition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransition.Name = "toolStripButtonTransition";
            this.toolStripButtonTransition.Size = new System.Drawing.Size(53, 35);
            this.toolStripButtonTransition.Text = "Перехід";
            this.toolStripButtonTransition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonTransition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.toolStripButtonTransition.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonArc
            // 
            this.toolStripButtonArc.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArc.Image")));
            this.toolStripButtonArc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArc.Name = "toolStripButtonArc";
            this.toolStripButtonArc.Size = new System.Drawing.Size(36, 35);
            this.toolStripButtonArc.Text = "Дуга";
            this.toolStripButtonArc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonArc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.toolStripButtonArc.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Petri.net";
            this.openFileDialog.Filter = "Petri nets|*.net|All files|*.*";
            this.openFileDialog.Title = "Відкрити файл";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Petri nets|*.net|All files|*.*";
            this.saveFileDialog.Title = "Зберегти в файл";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.властивостіToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(148, 26);
            // 
            // властивостіToolStripMenuItem
            // 
            this.властивостіToolStripMenuItem.Name = "властивостіToolStripMenuItem";
            this.властивостіToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.властивостіToolStripMenuItem.Text = "Властивості";
            this.властивостіToolStripMenuItem.Click += new System.EventHandler(this.властивостіToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.area);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormMain";
            this.Text = "Мережі Петрі";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideArea_MouseDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlace;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransition;
        private System.Windows.Forms.ToolStripButton toolStripButtonArc;
        private System.Windows.Forms.ToolStripMenuItem новаМережаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матрицыСетиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonPointer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сіткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem малюватиСіткуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem властивостіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem марковськийГрафToolStripMenuItem;
        public System.Windows.Forms.Label area;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem марковськийГрафToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem марковськийГрафToolStripMenuItem2;
    }
}

