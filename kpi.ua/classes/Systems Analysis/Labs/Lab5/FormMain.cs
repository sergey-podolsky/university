using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Petri
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Grid width
        /// </summary>
        public const int grid = 16, twoGrid = 2 * grid, halfGrid = grid / 2;

        /// <summary>
        /// Arrow drawer
        /// </summary>
        ArrowRenderer arrow = new ArrowRenderer(8, 0.30f, true);

        /// <summary>
        /// All elements including places and transitions available in the current net
        /// </summary>
        public static List<Element> elements = new List<Element>();

        /// <summary>
        /// Temporary arc to draw while user is dragging new dash arc
        /// </summary>
        List<PointF> tempArc = new List<PointF>();

        /// <summary>
        /// Temporary element user clicked to connect with other element via temporary arc
        /// </summary>
        Element tempElement = null;

        /// <summary>
        /// Temporary element user clicked to drag
        /// </summary>
        Element draggingElement = null;

        /// <summary>
        /// Current mouse position on area
        /// </summary>
        Point mouse;

        /// <summary>
        /// Selected place to view context menu
        /// </summary>
        Place placeSelected;

        /// <summary>
        /// From constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Drawing all the elements, arcs and grid on the area surface 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Draw grid
            if (малюватиСіткуToolStripMenuItem.Checked)
                g.FillRectangle(new System.Drawing.Drawing2D.HatchBrush(HatchStyle.DottedGrid, Color.LightBlue, Color.Transparent), area.ClientRectangle);

            // Draw temporary arcs
            if (tempElement != null)
            {
                Pen pen = new Pen(tempElement is Place ? Color.Red : Color.Blue, 2);
                pen.DashStyle = DashStyle.Dash;
                PointF[] points = new PointF[tempArc.Count + 2];
                points[0] = tempElement.location;
                tempArc.CopyTo(points, 1);
                points[points.Length - 1] = mouse;
                arrow.DrawArrows(g, pen, Brushes.White, points);
            }

            // Draw arks
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            foreach (Element element in elements)
                foreach (KeyValuePair<List<PointF>, Element> relation in element.next)
                {
                    PointF[] points = new PointF[relation.Key.Count + 2];
                    points[0] = element.location;
                    relation.Key.CopyTo(points, 1);
                    points[points.Length - 1] = relation.Value.location;
                    arrow.DrawArrows(g, new Pen(element is Place ? Brushes.Red : Brushes.Blue, 1), element is Place ? Brushes.Pink : Brushes.Cyan, points);
                }

            // Draw elements
            foreach (Element element in elements)
            {
                if (element is Place)
                {
                    g.FillEllipse(Brushes.Yellow, element.location.X - grid, element.location.Y - grid, twoGrid, twoGrid);
                    g.DrawEllipse(new Pen(Brushes.Black, 2), element.location.X - grid, element.location.Y - grid, twoGrid, twoGrid);
                    g.DrawString(((Place)element).markers.ToString(), new Font("Arial", halfGrid), Brushes.Black, element.location.X, element.location.Y - halfGrid, format);
                }
                else
                {
                    g.FillRectangle((element as Transition).active ? Brushes.Red : Brushes.Yellow, element.location.X - halfGrid, element.location.Y - grid, grid, twoGrid);
                    g.DrawRectangle(new Pen(Brushes.Black, 2), element.location.X - halfGrid, element.location.Y - grid, grid, twoGrid);
                }
                g.DrawString(element.name, new Font("Arial", halfGrid), Brushes.Black, element.location.X, element.location.Y + grid, format);
            }
        }

        /// <summary>
        /// User is changing drawing mode...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton button in toolStrip.Items)
                button.Checked = button == sender;
        }

        /// <summary>
        /// Clear all temporary dash arcs and free temporary element user clicked to connect
        /// </summary>
        void clearTemp()
        {
            tempElement = null;
            tempArc = new List<PointF>();
            GC.Collect();
            area.Invalidate();
        }

        /// <summary>
        /// Clear current net totally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новаМережаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elements.Clear();
        }

        /// <summary>
        /// Load net from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    saveFileDialog.FileName = openFileDialog.FileName;
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (Stream stream = File.OpenRead(openFileDialog.FileName))
                        elements = (List<Element>)formatter.Deserialize(stream);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            area.Invalidate();
        }

        /// <summary>
        /// Save current net to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.FileName == "")
                зберегтиЯкToolStripMenuItem_Click(null, null);
            else
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        formatter.Serialize(stream, elements);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// "Save as" current net to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                зберегтиToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Do specific action according to selected mode on MouseDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point((int)Math.Round((double)e.X / grid) * grid, (int)Math.Round((double)e.Y / grid) * grid);
            draggingElement = Element.GetByPoint(point, elements);

            if (e.Button == MouseButtons.Left)
            {
                if (toolStripButtonPlace.Checked && draggingElement == null)
                    elements.Add(new Place(point, elements));
                else if (toolStripButtonTransition.Checked && draggingElement == null)
                    elements.Add(new Transition(point, elements));
                else if (toolStripButtonArc.Checked)
                    if (tempElement == null) tempElement = draggingElement;
                    else if (draggingElement != null)
                        if (draggingElement.GetType() == tempElement.GetType())
                            MessageBox.Show("Позиція може з'єднуватись лише з переходом, а перехід з позицією!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        {
                            tempElement.next.Add(tempArc, draggingElement);
                            draggingElement.previous.Add(tempElement);
                            clearTemp();
                        }
                    else tempArc.Add(point);
                area.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && draggingElement is Place)
            {
                contextMenuStrip.Show(area, point);
                placeSelected = (Place)draggingElement;
            }
        }

        /// <summary>
        /// Drag elemnt on mouse move event or just invalidate area if user is drawing new arc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void area_MouseMove(object sender, MouseEventArgs e)
        {
            mouse = new Point((int)Math.Round((double)e.X / grid) * grid, (int)Math.Round((double)e.Y / grid) * grid);
            if (toolStripButtonPointer.Checked && draggingElement != null)
            {
                draggingElement.location = mouse;
                area.Invalidate();
            }
            else if (tempElement != null) area.Invalidate();
        }

        /// <summary>
        /// Free dragging element on user MouseUp event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            draggingElement = null;
        }

        /// <summary>
        /// Disable arc temporary connections on user outside area clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutsideArea_MouseDown(object sender, MouseEventArgs e)
        {
            clearTemp();
        }

        /// <summary>
        /// Exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Show matrixes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void матрицыСетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMatrix().ShowDialog();
        }

        /// <summary>
        /// Show place properies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void властивостіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormProperties(placeSelected).ShowDialog();
            area.Invalidate();
        }

        /// <summary>
        /// Invalidate area on draw grid click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void малюватиСіткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            area.Invalidate();
        }

        /// <summary>
        /// Show net at work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void роботаМережіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FormWork().ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Необхідно спочатку створити реальну мережу!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Show AboutBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBoxPetri().ShowDialog(this);
        }

        /// <summary>
        /// Show tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void марковськийГрафToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FormTree().ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Необхідно спочатку створити реальну мережу!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void марковськийГрафToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new FormMarkov().ShowDialog(area);
        }
    }
}
