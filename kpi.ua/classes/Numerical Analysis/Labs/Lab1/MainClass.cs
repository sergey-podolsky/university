using System;
using System.Windows.Forms;

namespace NumLab1
{
    public partial class MainClass : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainClass());
        }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вычисление следующего члена ряда
        /// </summary>
        /// <param name="U">Предыдущий член ряда</param>
        /// <param name="x">Угол</param>
        /// <param name="k">Номер вычисляемого члена ряда</param>
        /// <param name="BelowP4">если true - член ряда sin(x); иначе - cos(x)</param>
        /// <returns>Следующий член ряда</returns>
        double Next(double U, double x, int k, bool BelowP4)
        {
            return U * -1 * x * x / (2 * k * (2 * k + (BelowP4 ? 1 : -1)));
        }

        /// <summary>
        /// Приводит заданный угол к значению, принадлежащему отрезку [0; П/4]
        /// </summary>
        /// <param name="point">Исходный угол</param>
        /// <param name="belowP4">если true - необходимо вычислять sin(x); иначе - cos(x)</param>
        /// <returns>Приведённый угол в отрезке [0; П/4]</returns>
        double GetX(double point, out bool belowP4)
        {
            double x = Math.Abs(point) % Math.PI;
            if (x > Math.PI / 2) x = Math.PI - x;
            return (belowP4 = x <= Math.PI / 4) ? x : Math.PI / 2 - x;
        }

        /// <summary>
        /// Нажатие кнопки "Proceed"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // Проверки заданных пользователем параметров
            if (numericUpDownA.Value >= numericUpDownB.Value)
            {
                MessageBox.Show("\"b\" must be greater than \"a\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numericUpDownMaxEps.Value <= numericUpDownMinEps.Value)
            {
                MessageBox.Show("Value \"Maximum eps\" must be greater than \"Minimum eps\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Очистка таблиц
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            // Значения Eps(i)
            double minEps = Math.Pow(10, (double)numericUpDownMinEps.Value);
            double maxEps = Math.Pow(10, (double)numericUpDownMaxEps.Value);
            double stepEps = Math.Pow(10, (double)numericUpDownStepEps.Value);

            // Неприведённая точка Х в радианах
            double point = (double)(numericUpDownB.Value - numericUpDownA.Value) / 2;

            // Признак того, что при приведении значение угла меньше П/4
            // Используется для выбора формулы вычисления: sin(x) либо cos(x)
            bool belowP4;

            // Приведённый угол (0 < X < П/4)
            double x = GetX(point, out belowP4);

            // Номер шага в течение вычисления
            int k = 0;

            // Следующее слагаемое ряда
            double U = belowP4 ? x : 1, S = U, eps;

            // Заполнение таблицы для различных eps(i)
            for (eps = maxEps; eps >= minEps; eps *= stepEps)
            {
                while (Math.Abs(U) >= eps) S += U = Next(U, x, ++k, belowP4);
                dataGridView1.Rows.Add(eps, k, Math.Abs(Math.Abs(Math.Sin(point)) - (S - U)), U);
            }

            // Пределы интервала, на котором производятся вычисление
            double a = (double)numericUpDownA.Value;
            double b = (double)numericUpDownB.Value;

            // Приращение на данном интервале
            double h = (b - a) / (double)numericUpDownStepCount.Value;

            // Количество шагов, выполняемых для всех вычислений
            int n = (int)numericUpDownN.Value;

            // Заполнения таблицы для рызличных значений Хi
            for (point = a; point <= b; point += h)
            {
                x = GetX(point, out belowP4);
                S = U = belowP4 ? x : 1;
                for (k = 0; k < n;) S += U = Next(U, x, ++k, belowP4);
                dataGridView2.Rows.Add(point, Math.Abs(Math.Abs(Math.Sin(point)) - (S - U)), U);
            }
        }
    }
}
