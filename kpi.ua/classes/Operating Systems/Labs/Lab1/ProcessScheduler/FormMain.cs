using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessScheduler
{
    public partial class FormMain : Form
    {
        List<ProcessModel> InteractiveList = new List<ProcessModel>();
        List<ProcessModel> PackageList = new List<ProcessModel>();

        public FormMain()
        {
            InitializeComponent();
            // По замовчанню пакетний процес
            comboBoxMode.SelectedIndex = 1;
            trackBar_Scroll(null, null);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProcessModel process = new ProcessModel(textBoxPath.Text, (uint)numericUpDownIterations.Value, numericUpDownProcessNumber.Value++.ToString());
            process.Exited += new ProcessModel.ProcessExitedEventHandler(process_Exited);
            process.StartTime = DateTime.Now;
            if (comboBoxMode.SelectedIndex == 0) InteractiveList.Add(process);
            else if ((comboBoxMode.SelectedIndex == 1) || (PackageList.Count == 0)) PackageList.Add(process);
            else PackageList.Insert(1, process);
        }

        void ShiftList()
        {
            ProcessModel current = InteractiveList[0];
            InteractiveList.Remove(current);
            InteractiveList.Add(current);
        }

        int tacts = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = (int)numericUpDownInterval.Value * 1000;
            tacts++;

            foreach (ProcessModel process in PackageList) process.Active = false;
            foreach (ProcessModel process in InteractiveList) process.Active = false;

            if (percentPackade == 0) OnInteractive();
            else if (percentInteractive == 0) OnPackade();
            else if (percentInteractive > percentPackade)
                if (tacts % (percentInteractive / percentPackade + 1) == 0) OnPackade();
                else OnInteractive();
            else
                if (tacts % (percentPackade / percentInteractive + 1) == 0) OnInteractive();
                else OnPackade();
        }

        void OnInteractive()
        {
            if (InteractiveList.Count > 0)
            {
                InteractiveList[0].Active = true;
                ShiftList();
            }
            else if (PackageList.Count > 0)
                PackageList[0].Active = true;
        }

        void OnPackade()
        {
            if (PackageList.Count > 0)
                PackageList[0].Active = true;
            else if (InteractiveList.Count > 0)
            {
                InteractiveList[0].Active = true;
                ShiftList();
            }
        }

        void process_Exited(ProcessModel sender)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                dataGridView.Rows.Add(sender.ID, sender.StartTime.ToLongTimeString(), sender.ExitTime.ToLongTimeString(), sender.WorkTime, sender.SuspendTime, sender.TotalTime);
            }), null, null);
            PackageList.Remove(sender);
            InteractiveList.Remove(sender);
            timer_Tick(null, null);
        }

        int percentInteractive;
        int percentPackade;
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            percentInteractive = trackBar.Value;
            percentPackade = trackBar.Maximum - trackBar.Value;
            labelInteractivePercent.Text = percentInteractive.ToString() + " %";
            labelPackadePercent.Text = percentPackade.ToString() + " %";
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxPath.Text = openFileDialog.FileName;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new aboutBox().ShowDialog();
        }
    }
}
