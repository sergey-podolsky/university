using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Collections;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;

namespace NetworkRouting
{
    public partial class FormRouteTable : Form
    {
        public static bool TablesRequired = true;

        public FormRouteTable(Node node)
        {
            InitializeComponent();
            if (TablesRequired)
                createTables();
            foreach (var target in node.routeTable)
            {
                string line = string.Format("{0}:\t", target.Key.ID);
                foreach (var next in target.Value)
                    line += string.Format("{0}, ", next.ID);
                listBox.Items.Add(line.Substring(0, line.Length - 2));
            }
        }

        public static double[,] distanceTable;
        public static List<int>[,] pathTable;

        public static void createTables()
        {
            // Create graph
            var graph = new UndirectedGraph<int, Edge<int>>();

            // Add vertices to the graph
            for (var i = 0; i < FormMain.nodes.Count; i++)
                graph.AddVertex(i);

            // Create edges
            var edgeCost = new Dictionary<Edge<int>, double>();
            for (var i = 0; i < FormMain.edges.Count; i++)
            {
                var quickGraphEdge = new Edge<int>(FormMain.nodes.IndexOf(FormMain.edges[i].nodes[0]), FormMain.nodes.IndexOf(FormMain.edges[i].nodes[1]));
                graph.AddEdge(quickGraphEdge);
                edgeCost.Add(quickGraphEdge, FormMain.edges[i].Weight);
            }

            // Initialize tables
            distanceTable = new double[FormMain.nodes.Count, FormMain.nodes.Count];
            pathTable = new List<int>[FormMain.nodes.Count, FormMain.nodes.Count];
            for (var i = 0; i < FormMain.nodes.Count; i++)
                for (var j = 0; j < FormMain.nodes.Count; j++)
                {
                    distanceTable[i, j] = double.PositiveInfinity;
                    pathTable[i, j] = new List<int>();
                }

            // Create tables
            for (var source = 0; source < FormMain.nodes.Count; source++)
            {
                // We want to use Dijkstra on this graph
                var dijkstra = new UndirectedDijkstraShortestPathAlgorithm<int, Edge<int>>(graph, edge => edgeCost[edge]);

                // attach a distance observer to give us the shortest path distances
                var distObserver = new UndirectedVertexDistanceRecorderObserver<int, Edge<int>>(edge => edgeCost[edge]);
                distObserver.Attach(dijkstra);

                // Attach a Vertex Predecessor Recorder Observer to give us the paths
                var predecessorObserver = new UndirectedVertexPredecessorRecorderObserver<int, Edge<int>>();
                predecessorObserver.Attach(dijkstra);

                // Run the algorithm for current Node
                dijkstra.Compute(source);

                // Add values to table
                foreach (var target in distObserver.Distances)
                {
                    distanceTable[source, target.Key] = target.Value;
                    IEnumerable<Edge<int>> path;
                    if (predecessorObserver.TryGetPath(target.Key, out path))
                        pathTable[source, target.Key].AddRange(path.Select(edge => edge.Source).Concat(path.Select(edge => edge.Target)).Distinct().OrderBy(next => distObserver.Distances[next]));
                }
            }

            // Create route tables
            foreach (var source in FormMain.nodes)
                source.routeTable = FormMain.nodes.ToDictionary(target => target, target =>
                    (
                        from edge in FormMain.edges
                        where edge.nodes.Contains(source)
                        let adjacent = edge.nodes[0] != source ? edge.nodes[0] : edge.nodes[1]
                        where !pathTable[adjacent.ID, target.ID].Contains(source.ID)
                        orderby edge.Weight + distanceTable[adjacent.ID, target.ID] ascending
                        select adjacent
                    ).ToList());

            TablesRequired = false;
        }
    }
}
