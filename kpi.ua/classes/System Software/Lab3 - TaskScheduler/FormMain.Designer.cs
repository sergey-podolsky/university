namespace TaskScheduler
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonProceed = new System.Windows.Forms.Button();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelMaxTaskWeight = new System.Windows.Forms.Label();
            this.labelMaxIncomingInterval = new System.Windows.Forms.Label();
            this.labelIntervalVariation = new System.Windows.Forms.Label();
            this.labelColumnCount = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.numericUpDownPriorityCount = new System.Windows.Forms.NumericUpDown();
            this.labelPriorityCount = new System.Windows.Forms.Label();
            this.numericUpDownPriorityClasses = new System.Windows.Forms.NumericUpDown();
            this.labelPriorityClasses = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.labelSchedulingAlgorithm = new System.Windows.Forms.Label();
            this.checkBoxRegardCompleted = new System.Windows.Forms.CheckBox();
            this.numericUpDownVariationStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIntervalVariation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxIncomingInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxTaskWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTotalTime = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMakeEventList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriorityCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriorityClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariationStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxIncomingInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaskWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTime)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderlineWidth = 2;
            this.chart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartAreaIdle";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.Name = "ChartAreaVariation";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "ChartAreaIdle";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "LegendMain";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(394, 12);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartAreaIdle";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "LegendMain";
            series1.Name = "Processor idle";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartAreaIdle";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "LegendMain";
            series2.Name = "Task idle";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            series3.BackSecondaryColor = System.Drawing.Color.SkyBlue;
            series3.BorderColor = System.Drawing.Color.Gray;
            series3.ChartArea = "ChartAreaVariation";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Color = System.Drawing.Color.RoyalBlue;
            series3.IsValueShownAsLabel = true;
            series3.IsVisibleInLegend = false;
            series3.Legend = "LegendMain";
            series3.Name = "Variation";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(497, 538);
            this.chart.TabIndex = 50;
            this.chart.Text = "Statistics";
            title1.DockedToChartArea = "ChartAreaIdle";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.IsDockedInsideChartArea = false;
            title1.Name = "TitleIdle";
            title1.Text = "Processor / Task idle";
            title2.DockedToChartArea = "ChartAreaVariation";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title2.IsDockedInsideChartArea = false;
            title2.Name = "TitleVariation";
            title2.Text = "Variation";
            this.chart.Titles.Add(title1);
            this.chart.Titles.Add(title2);
            // 
            // buttonProceed
            // 
            this.buttonProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProceed.Location = new System.Drawing.Point(16, 513);
            this.buttonProceed.Name = "buttonProceed";
            this.buttonProceed.Size = new System.Drawing.Size(207, 37);
            this.buttonProceed.TabIndex = 0;
            this.buttonProceed.Text = "Proceed";
            this.buttonProceed.UseVisualStyleBackColor = true;
            this.buttonProceed.Click += new System.EventHandler(this.buttonProceed_Click);
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Location = new System.Drawing.Point(13, 13);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(56, 13);
            this.labelTotalTime.TabIndex = 3;
            this.labelTotalTime.Text = "Total time:";
            // 
            // labelMaxTaskWeight
            // 
            this.labelMaxTaskWeight.AutoSize = true;
            this.labelMaxTaskWeight.Location = new System.Drawing.Point(13, 39);
            this.labelMaxTaskWeight.Name = "labelMaxTaskWeight";
            this.labelMaxTaskWeight.Size = new System.Drawing.Size(87, 13);
            this.labelMaxTaskWeight.TabIndex = 3;
            this.labelMaxTaskWeight.Text = "Max task weight:";
            // 
            // labelMaxIncomingInterval
            // 
            this.labelMaxIncomingInterval.AutoSize = true;
            this.labelMaxIncomingInterval.Location = new System.Drawing.Point(13, 65);
            this.labelMaxIncomingInterval.Name = "labelMaxIncomingInterval";
            this.labelMaxIncomingInterval.Size = new System.Drawing.Size(112, 13);
            this.labelMaxIncomingInterval.TabIndex = 3;
            this.labelMaxIncomingInterval.Text = "Max incoming intarval:";
            // 
            // labelIntervalVariation
            // 
            this.labelIntervalVariation.AutoSize = true;
            this.labelIntervalVariation.Location = new System.Drawing.Point(13, 158);
            this.labelIntervalVariation.Name = "labelIntervalVariation";
            this.labelIntervalVariation.Size = new System.Drawing.Size(185, 13);
            this.labelIntervalVariation.TabIndex = 3;
            this.labelIntervalVariation.Text = "Max incoming intarval to get variation:";
            // 
            // labelColumnCount
            // 
            this.labelColumnCount.AutoSize = true;
            this.labelColumnCount.Location = new System.Drawing.Point(13, 215);
            this.labelColumnCount.Name = "labelColumnCount";
            this.labelColumnCount.Size = new System.Drawing.Size(145, 13);
            this.labelColumnCount.TabIndex = 3;
            this.labelColumnCount.Text = "Variation step (column width):";
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(229, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(159, 537);
            this.listBox.TabIndex = 4;
            // 
            // numericUpDownPriorityCount
            // 
            this.numericUpDownPriorityCount.Location = new System.Drawing.Point(128, 89);
            this.numericUpDownPriorityCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPriorityCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPriorityCount.Name = "numericUpDownPriorityCount";
            this.numericUpDownPriorityCount.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownPriorityCount.TabIndex = 2;
            this.numericUpDownPriorityCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelPriorityCount
            // 
            this.labelPriorityCount.AutoSize = true;
            this.labelPriorityCount.Location = new System.Drawing.Point(13, 91);
            this.labelPriorityCount.Name = "labelPriorityCount";
            this.labelPriorityCount.Size = new System.Drawing.Size(71, 13);
            this.labelPriorityCount.TabIndex = 3;
            this.labelPriorityCount.Text = "Priority count:";
            // 
            // numericUpDownPriorityClasses
            // 
            this.numericUpDownPriorityClasses.Location = new System.Drawing.Point(128, 115);
            this.numericUpDownPriorityClasses.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPriorityClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPriorityClasses.Name = "numericUpDownPriorityClasses";
            this.numericUpDownPriorityClasses.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownPriorityClasses.TabIndex = 2;
            this.numericUpDownPriorityClasses.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelPriorityClasses
            // 
            this.labelPriorityClasses.AutoSize = true;
            this.labelPriorityClasses.Location = new System.Drawing.Point(13, 117);
            this.labelPriorityClasses.Name = "labelPriorityClasses";
            this.labelPriorityClasses.Size = new System.Drawing.Size(79, 13);
            this.labelPriorityClasses.TabIndex = 3;
            this.labelPriorityClasses.Text = "Priority classes:";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "FIFO",
            "RR",
            "LLQ"});
            this.comboBox.Location = new System.Drawing.Point(15, 374);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(105, 21);
            this.comboBox.TabIndex = 5;
            // 
            // labelSchedulingAlgorithm
            // 
            this.labelSchedulingAlgorithm.AutoSize = true;
            this.labelSchedulingAlgorithm.Location = new System.Drawing.Point(12, 358);
            this.labelSchedulingAlgorithm.Name = "labelSchedulingAlgorithm";
            this.labelSchedulingAlgorithm.Size = new System.Drawing.Size(108, 13);
            this.labelSchedulingAlgorithm.TabIndex = 3;
            this.labelSchedulingAlgorithm.Text = "Scheduling algorithm:";
            // 
            // checkBoxRegardCompleted
            // 
            this.checkBoxRegardCompleted.AutoSize = true;
            this.checkBoxRegardCompleted.Checked = global::TaskScheduler.Properties.Settings.Default.RagardOnlyCompletedTasks;
            this.checkBoxRegardCompleted.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TaskScheduler.Properties.Settings.Default, "RagardOnlyCompletedTasks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxRegardCompleted.Location = new System.Drawing.Point(16, 269);
            this.checkBoxRegardCompleted.Name = "checkBoxRegardCompleted";
            this.checkBoxRegardCompleted.Size = new System.Drawing.Size(163, 17);
            this.checkBoxRegardCompleted.TabIndex = 6;
            this.checkBoxRegardCompleted.Text = "Reagrd only completed tasks";
            this.checkBoxRegardCompleted.UseVisualStyleBackColor = true;
            // 
            // numericUpDownVariationStep
            // 
            this.numericUpDownVariationStep.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskScheduler.Properties.Settings.Default, "VariationColumnCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownVariationStep.Location = new System.Drawing.Point(16, 231);
            this.numericUpDownVariationStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownVariationStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVariationStep.Name = "numericUpDownVariationStep";
            this.numericUpDownVariationStep.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownVariationStep.TabIndex = 2;
            this.numericUpDownVariationStep.Value = global::TaskScheduler.Properties.Settings.Default.VariationColumnCount;
            // 
            // numericUpDownIntervalVariation
            // 
            this.numericUpDownIntervalVariation.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskScheduler.Properties.Settings.Default, "VariationInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownIntervalVariation.Location = new System.Drawing.Point(16, 174);
            this.numericUpDownIntervalVariation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownIntervalVariation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIntervalVariation.Name = "numericUpDownIntervalVariation";
            this.numericUpDownIntervalVariation.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownIntervalVariation.TabIndex = 2;
            this.numericUpDownIntervalVariation.Value = global::TaskScheduler.Properties.Settings.Default.VariationInterval;
            // 
            // numericUpDownMaxIncomingInterval
            // 
            this.numericUpDownMaxIncomingInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskScheduler.Properties.Settings.Default, "MaxIncomingInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownMaxIncomingInterval.Location = new System.Drawing.Point(128, 63);
            this.numericUpDownMaxIncomingInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaxIncomingInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxIncomingInterval.Name = "numericUpDownMaxIncomingInterval";
            this.numericUpDownMaxIncomingInterval.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownMaxIncomingInterval.TabIndex = 2;
            this.numericUpDownMaxIncomingInterval.Value = global::TaskScheduler.Properties.Settings.Default.MaxIncomingInterval;
            this.numericUpDownMaxIncomingInterval.ValueChanged += new System.EventHandler(this.numericUpDownMaxIncomingInterval_ValueChanged);
            // 
            // numericUpDownMaxTaskWeight
            // 
            this.numericUpDownMaxTaskWeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskScheduler.Properties.Settings.Default, "MaxTaskWeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownMaxTaskWeight.Location = new System.Drawing.Point(128, 37);
            this.numericUpDownMaxTaskWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaxTaskWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxTaskWeight.Name = "numericUpDownMaxTaskWeight";
            this.numericUpDownMaxTaskWeight.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownMaxTaskWeight.TabIndex = 2;
            this.numericUpDownMaxTaskWeight.Value = global::TaskScheduler.Properties.Settings.Default.MaxTaskWeight;
            // 
            // numericUpDownTotalTime
            // 
            this.numericUpDownTotalTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskScheduler.Properties.Settings.Default, "TotalTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownTotalTime.Location = new System.Drawing.Point(128, 11);
            this.numericUpDownTotalTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTotalTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTotalTime.Name = "numericUpDownTotalTime";
            this.numericUpDownTotalTime.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownTotalTime.TabIndex = 2;
            this.numericUpDownTotalTime.Value = global::TaskScheduler.Properties.Settings.Default.TotalTime;
            // 
            // checkBoxMakeEventList
            // 
            this.checkBoxMakeEventList.AutoSize = true;
            this.checkBoxMakeEventList.Checked = global::TaskScheduler.Properties.Settings.Default.MakeEventList;
            this.checkBoxMakeEventList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMakeEventList.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TaskScheduler.Properties.Settings.Default, "MakeEventList", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxMakeEventList.Location = new System.Drawing.Point(16, 306);
            this.checkBoxMakeEventList.Name = "checkBoxMakeEventList";
            this.checkBoxMakeEventList.Size = new System.Drawing.Size(98, 17);
            this.checkBoxMakeEventList.TabIndex = 51;
            this.checkBoxMakeEventList.Text = "Make event list";
            this.checkBoxMakeEventList.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 562);
            this.Controls.Add(this.checkBoxMakeEventList);
            this.Controls.Add(this.checkBoxRegardCompleted);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.labelSchedulingAlgorithm);
            this.Controls.Add(this.labelColumnCount);
            this.Controls.Add(this.labelIntervalVariation);
            this.Controls.Add(this.labelPriorityClasses);
            this.Controls.Add(this.labelPriorityCount);
            this.Controls.Add(this.labelMaxIncomingInterval);
            this.Controls.Add(this.labelMaxTaskWeight);
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.numericUpDownVariationStep);
            this.Controls.Add(this.numericUpDownIntervalVariation);
            this.Controls.Add(this.numericUpDownPriorityClasses);
            this.Controls.Add(this.numericUpDownPriorityCount);
            this.Controls.Add(this.numericUpDownMaxIncomingInterval);
            this.Controls.Add(this.numericUpDownMaxTaskWeight);
            this.Controls.Add(this.numericUpDownTotalTime);
            this.Controls.Add(this.buttonProceed);
            this.Controls.Add(this.chart);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.Text = "Podolsky Sergey KV-64";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriorityCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriorityClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariationStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxIncomingInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaskWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonProceed;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalTime;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTaskWeight;
        private System.Windows.Forms.Label labelMaxTaskWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxIncomingInterval;
        private System.Windows.Forms.Label labelMaxIncomingInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalVariation;
        private System.Windows.Forms.Label labelIntervalVariation;
        private System.Windows.Forms.NumericUpDown numericUpDownVariationStep;
        private System.Windows.Forms.Label labelColumnCount;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.NumericUpDown numericUpDownPriorityCount;
        private System.Windows.Forms.Label labelPriorityCount;
        private System.Windows.Forms.NumericUpDown numericUpDownPriorityClasses;
        private System.Windows.Forms.Label labelPriorityClasses;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label labelSchedulingAlgorithm;
        private System.Windows.Forms.CheckBox checkBoxRegardCompleted;
        private System.Windows.Forms.CheckBox checkBoxMakeEventList;
    }
}

