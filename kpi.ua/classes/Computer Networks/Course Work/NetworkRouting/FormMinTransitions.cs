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
    public partial class FormMinTransitions : Form
    {
        /// <summary>
        /// Table to store values
        /// </summary>
        public DataTable tableDijkstra = new DataTable();

        /// <summary>
        /// Form constructor
        /// </summary>
        public FormMinTransitions()
        {
            InitializeComponent();
            dataGridView.DataSource = tableDijkstra;
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

            // Create graph
            var graph = new UndirectedGraph<int, Edge<int>>();

            // Add vertices to the graph
            for (var i = 0; i < FormMain.nodes.Count; i++)
                graph.AddVertex(i);

            // Create edges
            for (var i = 0; i < FormMain.edges.Count; i++)
            {
                var quickGraphEdge = new Edge<int>(FormMain.nodes.IndexOf(FormMain.edges[i].nodes[0]), FormMain.nodes.IndexOf(FormMain.edges[i].nodes[1]));
                graph.AddEdge(quickGraphEdge);
            }

            // Compute distances
            for (var source = 0; source < FormMain.nodes.Count; source++)
            {
                // We want to use Dijkstra on this graph
                var dijkstra = new UndirectedDijkstraShortestPathAlgorithm<int, Edge<int>>(graph, edge => 1);

                // attach a distance observer to give us the shortest path distances
                var distObserver = new UndirectedVertexDistanceRecorderObserver<int, Edge<int>>(edge => 1);
                distObserver.Attach(dijkstra);

                // Attach a Vertex Predecessor Recorder Observer to give us the paths
                var predecessorObserver = new UndirectedVertexPredecessorRecorderObserver<int, Edge<int>>();
                predecessorObserver.Attach(dijkstra);

                // Run the algorithm for current Node
                dijkstra.Compute(source);

                // Show distances
                foreach (var target in distObserver.Distances)
                {
                    tableDijkstra.Rows[source + 1][target.Key + 1] = target.Value.ToString();
                    IEnumerable<Edge<int>> edgePath;
                    if (predecessorObserver.TryGetPath(target.Key, out edgePath))
                    {
                        string str = " (";
                        foreach (var nodeID in edgePath.Select(edge => edge.Source).Concat(edgePath.Select(edge => edge.Target)).Distinct().OrderBy(next => distObserver.Distances[next]))
                            str += string.Format("{0}->", nodeID);
                        tableDijkstra.Rows[source + 1][target.Key + 1] += str.Substring(0, str.Length - 2) + ")";
                    }
                }
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }
    }
}
