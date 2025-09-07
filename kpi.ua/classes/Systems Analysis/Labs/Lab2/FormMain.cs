using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TravelingSalesman
{
    public partial class FormMain : Form
    {
        DataTable table = new DataTable("Таблица коммивояжера");

        int[] graph;

        public FormMain()
        {
            InitializeComponent();
            dataGridView.DataSource = table;

            // Заглавные строка и столбец
            table.Rows.Add(table.NewRow());
            table.Columns.Add(new DataColumn("N", typeof(double)));

            // Создание таблицы
            numericUpDown_ValueChanged(null, null);
        }

        /// <summary>
        /// Изменение ранга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Добавление столбцов
            for (int i = table.Rows.Count + 1; i <= numericUpDown.Value + 1; i++)
            {
                // Создание и добавление строки и столбца
                DataColumn column = new DataColumn((i - 1).ToString(), typeof(double));
                column.DefaultValue = 0;
                column.AllowDBNull = false;
                table.Columns.Add(column);
                table.Rows.Add(table.NewRow());
            }

            // Удаление столбцов
            for (int i = table.Rows.Count - 1; i > numericUpDown.Value; i--)
            {
                table.Columns.RemoveAt(i);
                table.Rows.RemoveAt(i);
            }
            // Значения столбцов и строк
            for (int i = 1; i < table.Rows.Count; i++)
            {
                table.Rows[0][i] = table.Rows[i][0] = i;
                table.Rows[i][i] = double.PositiveInfinity;
            }
            // Граф
            Reset();
        }

        /// <summary>
        /// Введено некоректное значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
        }

        /// <summary>
        /// Индекс минимального значения в строке
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        int MinInRow(int row)
        {
            int minInRow = 1;
            for (int column = 2; column < table.Columns.Count; column++)
                if ((double)table.Rows[row][column] < (double)table.Rows[row][minInRow])
                    minInRow = column;
            return minInRow;
        }

        /// <summary>
        /// Приведение по строкам
        /// </summary>
        /// <returns></returns>
        double DecreaseRows()
        {
            double S = 0;
            for (int row = 1; row < table.Rows.Count; row++)
            {
                int minInRow = MinInRow(row);
                double min = (double)table.Rows[row][minInRow];
                if (min > 0)
                {
                    for (int column = 1; column < table.Columns.Count; column++)
                        table.Rows[row][column] = (double)table.Rows[row][column] - min;
                    S += min;
                    if (checkBox.Checked) MessageBox.Show(string.Format("Приведена строка: {0}\nМинимальное значение: {1}", table.Rows[row][0], min));
                }
            }
            return S;
        }

        /// <summary>
        /// Индекс минимального значения в столбце
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        int MinInColumn(int column)
        {
            int minInColumn = 1;
            for (int row = 2; row < table.Rows.Count; row++)
                if ((double)table.Rows[row][column] < (double)table.Rows[minInColumn][column])
                    minInColumn = row;
            return minInColumn;
        }

        /// <summary>
        /// Приведение по столбцам
        /// </summary>
        /// <returns></returns>
        double DecreaseColumns()
        {
            double S = 0;
            for (int column = 1; column < table.Columns.Count; column++)
            {
                int minInColumn = MinInColumn(column);
                double min = (double)table.Rows[minInColumn][column];
                if (min > 0)
                {
                    for (int row = 1; row < table.Rows.Count; row++)
                        table.Rows[row][column] = (double)table.Rows[row][column] - min;
                    S += min;
                    if (checkBox.Checked) MessageBox.Show(string.Format("Приведён столбец: {0}\nМинимальное значение: {1}", table.Rows[0][column], min));
                }
            }
            return S;
        }

        // Выбор клетки
        void FindZeroCell()
        {
            // Список всех нулевых клеток {0 - value, 1 - row, 2 - column}
            List<double[]> zeroCells = new List<double[]>();
            // Поиск всех нулевых клеток
            for (int row = 1; row < table.Rows.Count; row++)
                for (int column = 1; column < table.Columns.Count; column++)
                    // Найдена нулевая клетка
                    if ((double)table.Rows[row][column] == 0)
                    {
                        table.Rows[row][column] = double.PositiveInfinity;
                        zeroCells.Add(new double[3] { (double)table.Rows[row][MinInRow(row)] + (double)table.Rows[MinInColumn(column)][column], row, column });
                        table.Rows[row][column] = 0;
                    }
            // Поиск максимальной нулевой клетки
            int max = 0;
            for (int cell = 1; cell < zeroCells.Count; cell++)
                if (zeroCells[cell][0] > zeroCells[max][0])
                    max = cell;
            // Проверка разветвления решения
            if (checkBoxBranches.Checked)
                for (int cell = 0; cell < zeroCells.Count; cell++)
                    if (cell != max && zeroCells[cell][0] == zeroCells[max][0])
                    {
                        FormMain branch = new FormMain();
                        branch.Text += " (ветвление решения)";
                        branch.numericUpDown.Value = numericUpDown.Value;
                        branch.dataGridView.DataSource = branch.table = table.Clone();
                        foreach (DataRow row in table.Rows)
                            branch.table.Rows.Add(row.ItemArray);
                        foreach (object item in listBox.Items)
                            branch.listBox.Items.Add(item);
                        branch.length.Text = length.Text;
                        branch.checkBox.Checked = checkBox.Checked;
                        branch.checkBoxBranches.Checked = true;
                        branch.graph = (int[])graph.Clone();
                        branch.DeleteCell((int)zeroCells[cell][1], (int)zeroCells[cell][2]);
                        branch.Show();
                    }
            // Выделение клетки
            DeleteCell((int)zeroCells[max][1], (int)zeroCells[max][2]);
        }

        /// <summary>
        /// Удаление клетки
        /// </summary>
        void DeleteCell(int i, int j)
        {
            // Получение пользовательских координат клетки row, column
            int row = Convert.ToInt16(table.Rows[i][0]);
            int column = Convert.ToInt16(table.Rows[0][j]);
            graph[row] = column;
            // Поиск симметричной клетки относительно главной диагонали с теми же пользовательскими координатами
            int r = 1;
            while (r < table.Rows.Count && Convert.ToInt16(table.Rows[r][0]) != column) r++;
            int c = 1;
            while (c < table.Columns.Count && Convert.ToInt16(table.Rows[0][c]) != row) c++;
            // Запрет обратного маршрута, если есть соответсвующая строка и столбец
            try
            {
                table.Rows[r][c] = double.PositiveInfinity;
            }
            catch { };
            // Удаление столбца и строки
            table.Rows.RemoveAt(i);
            table.Columns.RemoveAt(j);
            listBox.Items.Add(string.Format("Найдена часть маршрута:\t{0}->{1}", row, column));

            // Поиск завершён
            if (table.Rows.Count <= 1)
            {
                string item = "Найден путь: ";
                int next = 1;
                for (int k = 1; k < graph.Length; k++)
                {
                    item += next.ToString() + " -> ";
                    next = graph[next];
                }
                item += next.ToString();
                listBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Шаг вперёд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // Путь найден (меньше 1 клетки)
            if (table.Rows.Count <= 1)
            {
                MessageBox.Show("Посик завершён.\nДлина маршрута: " + length.Text, "Путь найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Приведение по строкам
            double S;
            if ((S = DecreaseRows()) > 0)
            {
                listBox.Items.Add("Приведение по строкам:\tE=" + S.ToString());
                length.Text = (Convert.ToDouble(length.Text) + S).ToString();
                return;
            }
            // Приведение по столбцам
            if ((S = DecreaseColumns()) > 0)
            {
                listBox.Items.Add("Приведение по столбцам:\tE=" + S.ToString());
                length.Text = (Convert.ToDouble(length.Text) + S).ToString();
                return;
            }
            // Поиск нулевых клеток
            FindZeroCell();
        }

        /// <summary>
        /// Сохранение таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                table.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema, true);
        }

        /// <summary>
        /// Загрузка таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.DataSource = table = new DataTable();
                    table.ReadXml(openFileDialog.FileName);
                    numericUpDown.Value = table.Rows.Count - 1;
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Раскраска таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.RowIndex == 0)
                e.CellStyle.BackColor = Color.Aquamarine;
        }

        /// <summary>
        /// Построить граф
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGraph_Click(object sender, EventArgs e)
        {
            new FormGraph(graph).ShowDialog(this);
        }

        /// <summary>
        /// Сбросить лог, длину пути, граф
        /// </summary>
        void Reset()
        {
            listBox.Items.Clear();
            length.Text = "0";
            graph = new int[(int)(numericUpDown.Value + 1)];
            // Только чтение заглавных строки и столбца
            dataGridView.Rows[0].ReadOnly = dataGridView.Columns[0].ReadOnly = true;
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogResult.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.CreateText(saveFileDialogResult.FileName);
                foreach (object line in listBox.Items)
                    sw.WriteLine(line.ToString());
                sw.Close();
            }
        }

        /// <summary>
        /// О программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog(this);
        }

        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void алгоритмДейкстрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDekstr(table).ShowDialog(this);
        }
    }
}
