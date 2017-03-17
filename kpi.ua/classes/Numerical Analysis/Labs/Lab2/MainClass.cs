using System;
using System.Windows.Forms;

namespace NumLab2
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
        /// Функция, заданная по варианту
        /// </summary>
        /// <param name="x">Аргумент в радианах</param>
        /// <returns>Значение функции</returns>
        double f(double x)
        {
            return 15 / x - x * x + 15;
        }

        /// <summary>
        /// Производная заданной по варианту функции
        /// </summary>
        /// <param name="x">Аргумент в радианах</param>
        /// <returns>Значение производной в точке</returns>
        double df(double x)
        {
            return -15 / (x * x) - 2 * x;
        }

        /// <summary>
        /// Нажатие кнопки "Proceed"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // Проверка заданных пользователем параметров
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

            // Пределы выделения корней, заданные пользователем
            double a = (double)numericUpDownA.Value;
            double b = (double)numericUpDownB.Value;

            // Проверка наличия корня уравнения в заданных пределах
            if (f(a) * f(b) >= 0)
            {
                MessageBox.Show("Condition \"f(a) * f(b) < 0\" must be executed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Знак, на который должна домножаться функция
            int sign = Math.Sign(df(a));

            double m1 = Math.Min(sign * df(a), sign * df(b));
            double M1 = Math.Max(sign * df(a), sign * df(b));

            if (Math.Sign(m1) != Math.Sign(M1))
            {
                MessageBox.Show("Condition \"0 < m1 <= f'(x) <= M1\" for f(x) or -f(x) must be executed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Очистка таблиц
            dataGridViewI.Rows.Clear();
            dataGridViewB.Rows.Clear();
            dataGridViewN.Rows.Clear();

            // Инициализация eps(i)
            double minEps = Math.Pow(10, (double)numericUpDownMinEps.Value);
            double maxEps = Math.Pow(10, (double)numericUpDownMaxEps.Value);
            double stepEps = Math.Pow(10, (double)numericUpDownStepEps.Value);

            double alpha = 1 / M1;
            double q = 1 - m1 / M1;

            // Заполнение таблиц
            for (double eps = maxEps; eps >= minEps; eps *= stepEps)
            {
                // Method of Successive Approximations
                double delta = (1 - q) / q * eps;
                int kI; // Количество выполняемых шагов методом итераций
                double x0 = (a + b) / 2;
                double x1 = x0 - alpha * sign * f(x0);
                for (kI = 0; Math.Abs(x0 - x1) > delta; kI++)
                {
                    x0 = x1;
                    x1 = x1 - alpha * sign * f(x1);
                }
                dataGridViewI.Rows.Add(eps, x1, delta);

                // Bisection Method
                int kB; // Количество выполняемых шагов методом бисекций
                delta = 2 * eps;
                double an = a, bn = b;
                for (kB = 0; bn - an >= delta; kB++)
                {
                    double p = (an + bn) / 2;
                    if (f(an) * f(p) < 0) bn = p;
                    else an = p;
                }
                dataGridViewB.Rows.Add(eps, (an + bn) / 2, eps);

                // Таблица сравнения скорости схождения методов
                dataGridViewN.Rows.Add(eps, kI, kB);
            }
        }
    }
}
