using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Collections;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;

namespace NetworkRouting
{
    public partial class FormMinDistances : Form
    {
        /// <summary>
        /// Table to store values
        /// </summary>
        public DataTable tableDijkstra = new DataTable();

        /// <summary>
        /// Form constructor
        /// </summary>
        public FormMinDistances()
        {
            InitializeComponent();
            dataGridView.DataSource = tableDijkstra;
            if (FormRouteTable.TablesRequired) FormRouteTable.createTables();
        }

        /// <summary>
        /// Backcolor of title row and column
        /// </summary>
        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.RowIndex == 0)
                e.CellStyle.BackColor = Color.Aquamarine;
        }

        /// <summary>
        /// Compute
        /// </summary>
        private void Form_Load(object sender, EventArgs e)
        {
            // Crete distance table
            tableDijkstra.Columns.Add();
            tableDijkstra.Rows.Add(tableDijkstra.NewRow());
            for (var i = 0; i < FormMain.nodes.Count; i++)
            {
                tableDijkstra.Columns.Add();
                tableDijkstra.Rows.Add(tableDijkstra.NewRow());
                tableDijkstra.Rows[0][i + 1] = tableDijkstra.Rows[i + 1][0] = i;
            }

            for (int i = 0; i < FormMain.nodes.Count; i++)
                for (int j = 0; j < FormMain.nodes.Count; j++)
                {
                    tableDijkstra.Rows[i + 1][j + 1] = FormRouteTable.distanceTable[i, j].ToString();
                    if (FormRouteTable.distanceTable[i, j] > 0 && FormRouteTable.distanceTable[i, j] < double.PositiveInfinity)
                    {
                        string stringPath = " (";
                        foreach (var nodeID in FormRouteTable.pathTable[i, j])
                            stringPath += string.Format("{0}->", nodeID);
                        tableDijkstra.Rows[i + 1][j + 1] += stringPath.Substring(0, stringPath.Length - 2) + ")";
                    }
                }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }
    }
}
