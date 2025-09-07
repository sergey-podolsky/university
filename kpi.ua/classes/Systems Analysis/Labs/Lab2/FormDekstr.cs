using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TravelingSalesman.Properties;

namespace TravelingSalesman
{
    public partial class FormDekstr : Form
    {
        /// <summary>
        /// Исходная таблица
        /// </summary>
        DataTable table;

        /// <summary>
        /// Точки расположения вершин графа
        /// </summary>
        Point[] points;

        /// <summary>
        /// Веса вершин графа
        /// </summary>
        double[] pointWeights;

        /// <summary>
        /// Отношение размера рисунка к размеру формы
        /// </summary>
        const double scale = 0.6;

        /// <summary>
        /// Пропорция расположения надписи веса дуги графа на линии
        /// </summary>
        float position;

        /// <summary>
        /// Еще необработанные вершини
        /// </summary>
        List<int> undone;


        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        public FormDekstr(DataTable Table)
        {
            InitializeComponent();
            table = Table;
            undone = new List<int>();
            for (int i = 1; i < table.Rows.Count; i++) undone.Add(i);
            pointWeights = new double[table.Rows.Count];
            numericUpDown.Maximum = table.Rows.Count - 1;
            trackBar_Scroll(null, null);
            numericUpDown_ValueChanged(null, null);
        }

        private void area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            // Центр формы
            Point center = new Point(area.Width / 2, area.Height / 2);
            // Угол приращения
            double angle = 2 * Math.PI / (table.Rows.Count - 1);
            // Радиус графа
            double r = scale * (center.X < center.Y ? center.X : center.Y);

            // Точки вершин графа
            points = new Point[table.Rows.Count];
            double a = 0;
            for (int i = 1; i < table.Rows.Count; i++, a += angle)
            {
                points[i] = new Point((int)(center.X - r * Math.Cos(a)), (int)(center.Y - r * Math.Sin(a)));
                g.DrawString(pointWeights[i].ToString(), new Font("Arial", 16), Brushes.Green, new Point((int)(center.X - (r + 40) * Math.Cos(a)) - 10, (int)(center.Y - (r + 40) * Math.Sin(a)) - 10));
            }

            // Линии графа
            for (int i = 1; i < table.Rows.Count; i++)
                for (int j = i + 1; j < table.Rows.Count; j++)
                    g.DrawLine(new Pen(Brushes.Bisque, 3), points[i], points[j]);

            // Веса линий графа
            for (int i = 1; i < table.Rows.Count; i++)
                for (int j = 1; j < table.Rows.Count; j++)
                    if (i != j)
                        g.DrawString(table.Rows[i][j].ToString(), new Font("Arial", 14), Brushes.Black, new PointF(points[i].X + (points[j].X - points[i].X) * position - 10, points[i].Y + (points[j].Y - points[i].Y) * position - 10));

            // Иконки и номера
            for (int i = 1; i < points.Length; i++)
            {
                Rectangle rec = new Rectangle(points[i].X - Resources.Town.Width / 2, points[i].Y - Resources.Town.Height / 2, Resources.Town.Width, Resources.Town.Height);
                g.DrawImage(TravelingSalesman.Properties.Resources.Town, rec);
                g.DrawString(i.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, rec, format);
                // Вычеркнутые
                if (!undone.Contains(i))
                {
                    Pen strikedOutPen = new Pen(Color.Blue, 3);
                    g.DrawLine(strikedOutPen, rec.Left, rec.Top, rec.Right, rec.Bottom);
                    g.DrawLine(strikedOutPen, rec.Right, rec.Top, rec.Left, rec.Bottom);        
                }
            }
        }

        /// <summary>
        /// Изменения положений весов дуг графа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            position = (float)trackBar.Value / 100f;
            area.Invalidate();
        }

        /// <summary>
        /// Следующая вершина
        /// </summary>
        int next;

        /// <summary>
        /// нажатие кнопки Шаг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // Деактивировать выбор начальной точки
            numericUpDown.Enabled = false;

            // Удалить текущую вершину из списка необработанных
            undone.Remove(next);

            // Перебор соседних вершин
            for (int i = 1; i < table.Rows.Count; i++)
                // Для каждой вершины кроме текущей переприсвоить вес, если старый вес больше
                if (undone.Contains(i) && pointWeights[i] > pointWeights[next] + (double)table.Rows[next][i])
                    pointWeights[i] = pointWeights[next] + (double)table.Rows[next][i];

            // Визуально обновить граф
            area.Invalidate();
            if (button.Enabled = undone.Count > 0)
            {
                // Следующая вершина
                int min = 0;
                for (int i = 1; i < undone.Count; i++)
                    if (pointWeights[undone[i]] < pointWeights[undone[min]])
                        min = i;
                next = undone[min];
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Инициализация весов вершин графа
            for (int i = 1; i < pointWeights.Length; i++)
                pointWeights[i] = double.PositiveInfinity;
            pointWeights[next = (int)numericUpDown.Value] = 0;
            area.Invalidate();
        }
    }
}
