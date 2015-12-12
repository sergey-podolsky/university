using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjectManagement
{
    public partial class FormMain : Form
    {
        public CheckBox[] checkboxes;

        public FormMain()
        {
            InitializeComponent(); //dataTable.ReadXml("project.xml");
            // Assign checkBoxes array
            checkboxes = new CheckBox[] { checkBox7, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = MessageBox.Show("Invalid input format", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.Cancel;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                dataTable.ReadXml(openFileDialog.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                dataTable.WriteXml(saveFileDialog.FileName);
        }

        /// <summary>
        /// Separators used to split dependencies
        /// </summary>
        static readonly char[] separators = { ' ', '\t', '\n', ',', ';' };

        /// <summary>
        /// Get node collection from dataGridView
        /// </summary>
        /// <returns>HashSet of nodes</returns>
        public HashSet<Node> GetNodes()
        {
            HashSet<Node> Nodes = new HashSet<Node>();
            // Enlist all nodes
            for (int row = 0; row < dataTable.Rows.Count; row++)
                Nodes.Add(new Node((string)dataTable.Rows[row][0], (int)dataTable.Rows[row][1]));
            // Create dependencies
            for (int row = 0; row < dataTable.Rows.Count; row++)
                if (dataTable.Rows[row][2] != null)
                    foreach (string dependency in dataTable.Rows[row][2].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries))
                        Nodes.ElementAt(row).Dependencies.Add(Nodes.Single(new Func<Node, bool>(delegate(Node node)
                        {
                            return node.ID == dependency;
                        })));
            return Nodes;
        }

        /// <summary>
        /// Show charts
        /// </summary>
        private void run_Click(object sender, EventArgs e)
        {
            try
            {
                // Check constraints
                if (dataTable.Rows.Count == 0)
                    throw new Exception("Table is empty");
                if (checkboxes.All(new Func<CheckBox, bool>(delegate(CheckBox checkBox) { return !checkBox.Checked; })))
                    throw new Exception("There is no any workday checked");
                // Show chart forms
                new FormGanttChart().Show();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
