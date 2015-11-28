using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GeneticClusteringAlgorithm
{
    public partial class FormMain : Form
    {
        public const int pointRadius = 3, pointDiameter = 2 * pointRadius, sqrPointDiameter = pointDiameter * pointDiameter;
        List<Point> points = new List<Point>();
        List<Cluster> clusters = new List<Cluster>();

        public FormMain()
        {
            InitializeComponent();
        }

        class Cluster
        {
            public IEnumerable<Point> Set;
            public Brush Brush;
        }

        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Secont point</param>
        /// <returns>Distance in pixels</returns>
        public static double Distance(Point point1, Point point2)
        {
            int dx = point1.X - point2.X, dy = point1.Y - point2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Redraw all points
        /// </summary>
        private void area_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // Draw all vertices
            foreach (var point in points)
                e.Graphics.FillEllipse(Brushes.Red, point.X - pointRadius, point.Y - pointRadius, pointDiameter, pointDiameter);
            // Draw clusters
            foreach (var cluster in clusters)
                foreach (var point in cluster.Set)
                    e.Graphics.FillEllipse(cluster.Brush, point.X - pointRadius, point.Y - pointRadius, pointDiameter, pointDiameter);
        }

        /// <summary>
        /// Generate random point near given point
        /// </summary>
        /// <param name="x">X-coord of given point</param>
        /// <param name="y">Y-coord of given point</param>
        /// <param name="dispersion">Distance scale between random and given points</param>
        /// <returns>Random point</returns>
        Point RandomPoint(int x, int y, double dispersion)
        {
            var angle = 2 * Math.PI * GA.random.NextDouble();
            var radius = dispersion * (1.0 / Math.Sqrt(GA.random.NextDouble()) - GA.random.NextDouble());
            return new Point(x + (int)(radius * Math.Cos(angle)), y + (int)(radius * Math.Sin(angle)));
        }

        /// <summary>
        /// Mouse down
        /// </summary>
        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            if (2 * points.Count * sqrPointDiameter > area.Width * area.Height)
            {
                MessageBox.Show("Too many vertices already exist");
                return;
            }
            var MaxDispersion = Math.Min(area.Width, area.Height);
            for (var i = 0; i < numericUpDownVertecesPerClick.Value; i++)
            {
                Point point;
                var dispersion = (double)numericUpDownDispersion.Value;
                do
                {
                    point = RandomPoint(e.X, e.Y, dispersion);
                    if (dispersion < MaxDispersion) dispersion *= 1.1;
                }
                while (!area.ClientRectangle.Contains(point) || points.Any(anyPoint => Distance(point, anyPoint) <= pointDiameter));
                points.Add(point);
            }
            area.Invalidate();
        }

        /// <summary>
        /// Clear all
        /// </summary>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clusters.Clear();
            points.Clear();
            area.Invalidate();
        }

        /// <summary>
        /// Run GA
        /// </summary>
        private void runGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            points = points.OrderBy(_ => GA.random.Next()).ToList();
            clusters.Clear();
            backgroundWorker.RunWorkerAsync();
            runGAToolStripMenuItem.Enabled = clearVertecesToolStripMenuItem.Enabled = false;
            stopGAToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Stop GA
        /// </summary>
        private void stopGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        /// <summary>
        /// GA reproduction iterations in a single thread
        /// </summary>
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var startTime = DateTime.Now;
            var pointsLeft = points.ToArray();
            // Do clusterization until there are unclustered points left
            try
            {        
                var sizes = (from line in textBoxSizes.Lines where line != string.Empty let s = int.Parse(line) orderby s descending select s).ToArray();
                for (int clusterNumber = 0, size = sizes[0]; pointsLeft.Length > size; size = ++clusterNumber < sizes.Length ? sizes[clusterNumber] : sizes.Last())
                {
                    // Run new GA for next single cluster
                    var ga = new GA(pointsLeft, size);
                    var solution = new KeyValuePair<IEnumerable<int>, double>(Enumerable.Empty<int>(), 0);
                    // Do reproduction unless stop criterion is reached
                    for (int generation = 0, deadlocks = 0; deadlocks < 10 /* Stop criterion*/; generation++)
                    {
                        // Terminate GA on user request
                        if (e.Cancel = backgroundWorker.CancellationPending) return;
                        // Do reproduction
                        var newSolution = ga.Reproduction();
                        deadlocks = newSolution.Value == solution.Value ? deadlocks + 1 : 0;
                        solution = newSolution;
                        backgroundWorker.ReportProgress(generation, Tuple.Create<Point[], double, TimeSpan>((from index in solution.Key select pointsLeft[index]).ToArray(), solution.Value, DateTime.Now - startTime));
                    }
                    // Reduce available points by clusterized set of points
                    pointsLeft = pointsLeft.Except(from index in solution.Key select pointsLeft[index]).ToArray();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// GA terminated
        /// </summary>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            runGAToolStripMenuItem.Enabled = clearVertecesToolStripMenuItem.Enabled = true;
            stopGAToolStripMenuItem.Enabled = false;
            toolStripStatusLabelGeneration.Text = e.Cancelled ? "Cancelled by user" : "Completed";
        }

        /// <summary>
        /// Refresh data vizualization
        /// </summary>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var tuple = (Tuple<Point[], double, TimeSpan>)e.UserState;
            if (e.ProgressPercentage == 0)
                clusters.Add(new Cluster { Set = tuple.Item1, Brush = new SolidBrush(Color.FromArgb(GA.random.Next(256), GA.random.Next(256), GA.random.Next(256))) });
            else
                clusters.Last().Set = tuple.Item1;
            area.Invalidate();
            toolStripStatusLabelGeneration.Text = e.ProgressPercentage.ToString();
            toolStripStatusLabelTime.Text = tuple.Item3.ToString(@"mm\:ss");
            toolStripStatusLabelFitness.Text = tuple.Item2.ToString();
        }

        /// <summary>
        /// Save to file
        /// </summary>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    if (saveFileDialog.FilterIndex == 1)
                        using (var stream = File.Create(saveFileDialog.FileName))
                            new XmlSerializer(typeof(List<Point>)).Serialize(stream, points);
                    else
                        using (var stream = File.CreateText(saveFileDialog.FileName))
                            foreach (var point in points)
                                stream.WriteLine("{0}\t{1}", point.X, point.Y);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open from file
        /// </summary>
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FilterIndex == 1)
                        using (var stream = File.OpenRead(openFileDialog.FileName))
                            points = (List<Point>)new XmlSerializer(typeof(List<Point>)).Deserialize(stream);
                    else
                        using (var stream = File.OpenText(openFileDialog.FileName))
                            points = (from line in stream.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) let xy = from coord in line.Split('\t') select int.Parse(coord) select new Point(xy.First(), xy.Last())).ToList();
                    clusters.Clear();
                    area.Invalidate();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
