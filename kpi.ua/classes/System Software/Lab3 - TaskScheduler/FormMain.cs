using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TaskScheduler
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            // Add comboBox value to user settings
            comboBox.DataBindings.Add("SelectedIndex", TaskScheduler.Properties.Settings.Default, "SchedulingAlgorithm");
            numericUpDownIntervalVariation.Maximum = numericUpDownMaxIncomingInterval.Value;
        }

        private void buttonProceed_Click(object sender, EventArgs e)
        {
            // Clear all previous results
            listBox.Items.Clear();
            foreach (Series series in chart.Series)
                series.Points.Clear();

            List<DataPoint> points0 = new List<DataPoint>();
            List<DataPoint> points1 = new List<DataPoint>();

            // Start scheduler with different incoming task intensities
            for (int incomingInterval = (int)numericUpDownMaxIncomingInterval.Value; incomingInterval >= 1; incomingInterval--)
            {
                // Choose scheduler algorithm
                Scheduler scheduler;
                if (comboBox.SelectedItem == null) return;
                string algorithm = (string)comboBox.SelectedItem.ToString();
                if (algorithm == "FIFO") scheduler = new SchedulerFIFO();
                else if (algorithm == "RR") scheduler = new SchedulerRR();
                else if (algorithm == "LLQ") scheduler = new SchedulerLLQ();
                else return;

                // Regard only completed task or all tasks that entered
                List<Task> taskList = checkBoxRegardCompleted.Checked ? scheduler.TasksLeaved : scheduler.TasksEntered;

                // Add event to list box
                if (checkBoxMakeEventList.Checked && incomingInterval == (int)numericUpDownIntervalVariation.Value)
                    scheduler.TaskCompleted += new Scheduler.TaskCompletedEventHandler(delegate(Task task, int time)
                        {
                            listBox.Items.Add(time.ToString() + ":\tTask completed");
                        });

                // FORCE SCHEDULING
                Random random = new Random(DateTime.Now.Millisecond);
                int next = random.Next(1, incomingInterval);
                for (scheduler.Time = 0; scheduler.Time < numericUpDownTotalTime.Value; scheduler.Time++)
                    if (--next == 0)
                    {
                        Task task = new Task(random.Next(1, (int)numericUpDownMaxTaskWeight.Value), (int)numericUpDownPriorityCount.Value, (int)numericUpDownPriorityClasses.Value);
                        task.EndTime = (int)numericUpDownTotalTime.Value;
                        scheduler.AddTask(task);
                        next = random.Next(1, incomingInterval);
                        // Add event to list box
                        if (checkBoxMakeEventList.Checked && incomingInterval == (int)numericUpDownIntervalVariation.Value)
                            listBox.Items.Add(scheduler.Time.ToString() + "\tTask entered");
                    }

                // Add points to chart
                double intensity = (double)taskList.Count / (double)numericUpDownTotalTime.Value;
                points0.Add(new DataPoint(intensity, scheduler.IdleTime));
                points1.Add(new DataPoint(intensity, taskList.Average(new Func<Task, double>(delegate(Task task)
                    {
                        return task.IdleTime;
                    }))));

                // Draw variation
                if (incomingInterval == (int)numericUpDownIntervalVariation.Value)
                {
                    int MaxTaskIdle = taskList.Max<Task>(new Func<Task, int>(delegate(Task task)
                        {
                            return task.IdleTime;
                        }));
                    chart.ChartAreas[1].AxisX.Maximum = MaxTaskIdle + (int)numericUpDownVariationStep.Value - MaxTaskIdle % (int)numericUpDownVariationStep.Value;
                    for (int idle = 0; idle <= MaxTaskIdle; idle += (int)numericUpDownVariationStep.Value)
                        chart.Series[2].Points.AddXY(idle + (int)numericUpDownVariationStep.Value / 2, taskList.Count(new Func<Task, bool>(delegate(Task task)
                            {
                                return task.IdleTime >= idle && task.IdleTime < idle + (int)numericUpDownVariationStep.Value;
                            })));
                }
            }

            points0.Sort(new Comparison<DataPoint>(delegate(DataPoint p1, DataPoint p2)
                 {
                     return p1.XValue >= p2.XValue ? 1 : -1;
                 }));
            points1.Sort(new Comparison<DataPoint>(delegate(DataPoint p1, DataPoint p2)
            {
                return p1.XValue >= p2.XValue ? 1 : -1;
            }));
            foreach (DataPoint point in points0)
                chart.Series[0].Points.AddXY(point.XValue, point.YValues[0]);
            foreach (DataPoint point in points1)
                chart.Series[1].Points.AddXY(point.XValue, point.YValues[0]);
        }

        /// <summary>
        /// Check constraints
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownMaxIncomingInterval_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownIntervalVariation.Maximum = numericUpDownMaxIncomingInterval.Value;
        }
    }
}
