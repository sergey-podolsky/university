using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravelingSalesman.Properties;

namespace TravelingSalesman
{
    public partial class FormGraph : Form
    {
        int[] Graph;

        const double scale = 0.8;

        Font font = new Font("Arial", 20, FontStyle.Bold);
        StringFormat format = new StringFormat();
        Pen pen1 = new Pen(Brushes.Yellow, 3);
        Pen pen2 = new Pen(Brushes.DarkRed, 3);


        public FormGraph(int[] graph)
        {
            InitializeComponent();
            Graph = graph;
            format.Alignment = StringAlignment.Center;
        }

        private void area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point center = new Point(area.Width / 2, area.Height / 2);
            double angle = 2 * Math.PI / (Graph.Length - 1);
            double r = scale * (center.X < center.Y ? center.X : center.Y);

            Point[] points = new Point[Graph.Length];
            double a = 0;
            for (int i = 1; i < Graph.Length; i++, a += angle)
                points[i] = new Point((int)(center.X - r * Math.Cos(a)), (int)(center.Y - r * Math.Sin(a)));

            // Все пути
            for (int i = 1; i < Graph.Length; i++)
                for (int j = i + 1; j < Graph.Length; j++)
                    g.DrawLine(pen1, points[i], points[j]);
            

            // Кратчайший путь
            for (int i = 1; i < Graph.Length; i++)
                if (Graph[i] > 0)
                    g.DrawLine(pen2, points[i], points[Graph[i]]);

            // Иконки
            for (int i = 1; i < points.Length; i++)
            {
                Rectangle rec = new Rectangle(points[i].X - Resources.Town.Width / 2, points[i].Y - Resources.Town.Height / 2, Resources.Town.Width, Resources.Town.Height);
                g.DrawImage(TravelingSalesman.Properties.Resources.Town, rec);
                g.DrawString(i.ToString(), font, Brushes.Black, rec, format);
            }
        }
    }
}
