using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NetworkRouting.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NetworkRouting
{
    public partial class FormMain : Form
    {
        public static readonly List<Node> nodes = new List<Node>();
        public static readonly List<Edge> edges = new List<Edge>();

        public static int Tact = 0;

        /// <summary>
        /// Clicked node
        /// </summary>
        Node leftClickedNode = null, rightClickedNode;

        /// <summary>
        /// Clicked edge
        /// </summary>
        Edge rightClickedEdge = null;

        /// <summary>
        /// Form constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draw nodes and edges
        /// </summary>
        private void area_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            var stringFormat = new StringFormat { Alignment = StringAlignment.Center };

            // Draw grid
            if (drawGridToolStripMenuItem.Checked)
                g.FillRectangle(new HatchBrush(HatchStyle.DottedGrid, Color.Aquamarine, Color.Transparent), area.ClientRectangle);

            // Draw new temporary edge
            if (toolStripButtonEdge.Checked && leftClickedNode != null)
                g.DrawLine(new Pen(Brushes.OrangeRed, 2), leftClickedNode.Center, area.PointToClient(MousePosition));

            // Draw permanent edges
            foreach (var edge in edges)
            {
                g.DrawLine(new Pen(Brushes.Blue, edge.FullDuplex ? 4 : 2) { DashStyle = edge.Enabled ? DashStyle.Solid : DashStyle.Dash }, edge.nodes[0].Center, edge.nodes[1].Center);
                g.DrawString(edge.Weight.ToString(), Settings.Default.fontEdge, Brushes.Black, edge.Center, stringFormat);
                // Draw packets
                if (edge.Enabled)
                {
                    if (edge.packets[0] != null)
                    {
                        g.DrawImage(Packet.icon, (int)(edge.nodes[0].Center.X + edge.packets[0].Progress * (edge.nodes[1].Location.X - edge.nodes[0].Location.X)) - Packet.icon.Width / 2, (int)(edge.nodes[0].Center.Y + edge.packets[0].Progress * (edge.nodes[1].Location.Y - edge.nodes[0].Location.Y)) - Packet.icon.Height / 2);
                    }
                    if (edge.packets[1] != null)
                    {
                        g.DrawImage(Packet.icon, (int)(edge.nodes[1].Center.X + edge.packets[1].Progress * (edge.nodes[0].Location.X - edge.nodes[1].Location.X)) - Packet.icon.Width / 2, (int)(edge.nodes[1].Center.Y + edge.packets[1].Progress * (edge.nodes[0].Location.Y - edge.nodes[1].Location.Y)) - Packet.icon.Height / 2);
                    }
                }
            }

            // Draw nodes
            foreach (var node in nodes)
            {
                var rect = new Rectangle(node.Location, Node.icon1.Size);
                g.DrawImage(node.Enabled ? Node.icon1 : Node.icon2, rect);
                g.DrawString(nodes.IndexOf(node).ToString(), Settings.Default.fontNode, Brushes.Red, rect, stringFormat);
            }
        }

        /// <summary>
        /// User is changing drawing mode...
        /// </summary>
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            if (toolStrip.Items.IndexOf(sender as ToolStripItem) < 3)
                for (var i = 0; i < 3; i++)
                    (toolStrip.Items[i] as ToolStripButton).Checked = toolStrip.Items[i] == sender;
        }

        /// <summary>
        /// User clicks on area
        /// </summary>
        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var target = nodes.FirstOrDefault(node => node.Contains(e.Location));
                if (toolStripButtonNode.Checked && target == null)
                {
                    nodes.Add(new Node { Center = e.Location });
                    FormRouteTable.TablesRequired = true;
                }
                else if (toolStripButtonPointer.Checked || toolStripButtonEdge.Checked)
                    leftClickedNode = target;
                area.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (null != (rightClickedNode = nodes.FirstOrDefault(node => node.Contains(e.Location))))
                    contextMenuStripNode.Show(area, e.Location);
                else if (null != (rightClickedEdge = edges.FirstOrDefault(edge => edge.Contains(e.Location))))
                    contextMenuStripEdge.Show(area, e.Location);
            }
        }

        /// <summary>
        /// User moves the mouse over the area
        /// </summary>
        private void area_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftClickedNode != null)
            {
                if (toolStripButtonPointer.Checked && area.ClientRectangle.Contains(e.Location))
                    leftClickedNode.Center = e.Location;
                area.Invalidate();
            }
        }

        /// <summary>
        /// User releases the mouse
        /// </summary>
        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (toolStripButtonEdge.Checked && leftClickedNode != null)
                {
                    var target = nodes.FirstOrDefault(node => node.Contains(e.Location));
                    if (target != null && target != leftClickedNode && !edges.Any(edge => edge.nodes.Contains(leftClickedNode) && edge.nodes.Contains(target)))
                    {
                        edges.Add(new Edge { nodes = new[] { leftClickedNode, target } });
                        FormRouteTable.TablesRequired = true;
                    }
                }
                leftClickedNode = null;
                area.Invalidate();
            }
        }

        /// <summary>
        /// Show/hide grid
        /// </summary>
        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            area.Invalidate();
        }

        /// <summary>
        /// Clear current net totally
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodes.Clear();
            edges.Clear();
            area.Invalidate();
        }

        /// <summary>
        /// Save
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.FileName == string.Empty)
                saveAsToolStripMenuItem_Click(null, null);
            else
                try
                {
                    using (Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        new BinaryFormatter().Serialize(stream, new object[] { nodes, edges });
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        /// <summary>
        /// Save as...
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                saveToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Open...
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    saveFileDialog.FileName = openFileDialog.FileName;
                    using (Stream stream = File.OpenRead(openFileDialog.FileName))
                    {
                        object[] obj = (object[])new BinaryFormatter().Deserialize(stream);
                        nodes.Clear();
                        edges.Clear();
                        nodes.AddRange(obj[0] as IEnumerable<Node>);
                        edges.AddRange(obj[1] as IEnumerable<Edge>);
                        FormRouteTable.TablesRequired = true;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            area.Invalidate();
        }

        /// <summary>
        /// Randomize weights
        /// </summary>
        private void randomizeWeightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var edge in edges)
                edge.Weight = Edge.weights[Edge.random.Next(Edge.weights.Length)];
            FormRouteTable.TablesRequired = true;
            area.Invalidate();
        }

        /// <summary>
        /// Remove node
        /// </summary>
        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edges.RemoveAll(edge => edge.nodes.Contains(rightClickedNode));
            nodes.Remove(rightClickedNode);
            FormRouteTable.TablesRequired = true;
            area.Invalidate();
        }

        /// <summary>
        /// Remove edge
        /// </summary>
        private void removeEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edges.Remove(rightClickedEdge);
            FormRouteTable.TablesRequired = true;
            area.Invalidate();
        }

        /// <summary>
        /// Show distance table
        /// </summary>
        private void computeDistancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMinDistances().Show();
        }

        /// <summary>
        /// Show transition count table
        /// </summary>
        private void computeTransitionCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMinTransitions().Show();
        }

        /// <summary>
        /// Show edge properties window
        /// </summary>
        private void edgePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new FormEdgeProperties(rightClickedEdge).ShowDialog() == DialogResult.OK)
                area.Invalidate();
        }

        /// <summary>
        /// Show edge properties
        /// </summary>
        private void nodePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new FormNodeProperties(rightClickedNode).ShowDialog() == DialogResult.OK)
                area.Invalidate();
        }

        /// <summary>
        /// Show route table window
        /// </summary>
        private void showRouteTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormRouteTable(rightClickedNode).Show();
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            toolStripButtonPlay.Checked = !toolStripButtonPlay.Checked;
            timer.Enabled = toolStripButtonPlay.Checked;
            toolStripButtonPlay.Image = toolStripButtonPlay.Checked ? Resources.Pause : Resources.Play;
            toolStripButtonPlay.Text = toolStripButtonPlay.Checked ? "Pause" : "Run";
        }

        private void toolStripButtonStep_Click(object sender, EventArgs e)
        {
            if (FormRouteTable.TablesRequired)
                FormRouteTable.createTables();
            foreach (var edge in edges)
                if (edge.Enabled)
                    edge.SendPackets();
            foreach (var node in nodes)
                if (node.Enabled)
                    node.SendPackets();
            Tact++;
            area.Invalidate();
        }

        private void sendMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formSend.Show();
        }

        private void showDeliveryStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formStatistics.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutNerworkRouting().ShowDialog();
        }
    }
}
