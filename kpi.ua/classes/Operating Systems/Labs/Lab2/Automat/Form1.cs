using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace Automat
{
    public partial class FormAutomat : Form
    {
        /// <summary>
        /// Масив можливих номіналів монет
        /// </summary>
        int[] dignity = new int[] { 100, 50, 25, 10, 5, 2, 1 };

        /// <summary>
        /// Масив компонентів форми для відображення кількості наявних монет кожного номіналу
        /// </summary>
        NumericUpDown[] numerics;

        /// <summary>
        /// Делагат для обробки події зміни користувачем кількості наявних монет
        /// </summary>
        EventHandler handler;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormAutomat()
        {
            InitializeComponent();
            numerics = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7 };
            handler = new EventHandler(numericUpDown1_ValueChanged);
            foreach (NumericUpDown numeric in numerics) numeric.ValueChanged += handler;
            handler(null, null);
            comboBoxPut.SelectedIndex = 2;
        }

        /// <summary>
        /// Двійковий семафор для контролю доступу до скарбниці автомата (наявних монет)
        /// Початковий стан: 1
        /// Максимальне значення: 1
        /// </summary>
        Semaphore semaphore = new Semaphore(1, 1);

        /// <summary>
        /// Скарбниця автомату - список наявних монет усіх номіналів
        /// </summary>
        List<int> treasury = new List<int>();

        /// <summary>
        /// Вкидування однієї монети в натисненням кнопки автомат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPut_Click(object sender, EventArgs e)
        {
            Put(dignity[comboBoxPut.SelectedIndex]);
        }

        /// <summary>
        /// Вкинути монету в автомат для розміну
        /// </summary>
        /// <param name="chink">номінал монети</param>
        void Put(int chink)
        {
            /* Чекати, пока звільниться доступ до казни, і опустити семафор */
            semaphore.WaitOne();
            // Ідентифікувати і додати монету до скарбниці.
            // Передбачається виконання в поточному процесі
            treasury.Add(chink);
            /* Підняти семафор */
            semaphore.Release();

            // Створити новий поток для виконання операції розміну монети
            new Thread(new ThreadStart(delegate {
                /* Чекати, пока звільниться доступ до казни, і опустити семафор */
                semaphore.WaitOne();
                // Виконати операцію розміну
                ExchangeAndGive(chink);
                /* Підняти семафор */
                semaphore.Release();
            })).Start();

            /* Чекати, пока звільниться доступ до казни, і опустити семафор */
            semaphore.WaitOne();
            // Вивести на форму наявність монет
            // Передбачається виконання в поточному процесі
            ShowTreasury();
            /* Підняти семафор */
            semaphore.Release();
        }

        /// <summary>
        /// Метод  для розміну монети мінімальну кількість інших монет, менших за номіналом
        /// </summary>
        /// <param name="chink">Номінал монети</param>
        void ExchangeAndGive(int chink)
        {
            // Алгоритм розміну й видачі монет
            string s = DateTime.Now.ToLongTimeString() + "  Вкинуто: " + chink.ToString() + ";  отримано: ";
            List<int> output = new List<int>();
            if (Exchange(chink, output, false))
            {
                foreach (int c in output) s += c.ToString() + ", ";
                s = s.Substring(0, s.Length - 2);
            }
            else
            {
                treasury.Remove(chink);
                s += chink.ToString() + " (Немає монет для розміну)";
            }
            BeginInvoke(new EventHandler(delegate { listBoxLog.Items.Add(s); }));
        }

        /// <summary>
        /// Рекурсивний метод для видачі заданої суми зі скарбниці
        /// </summary>
        /// <param name="SumLeft">Сума, яку необхідно видати в монетах</param>
        /// <param name="input">Скарбниця</param>
        /// <param name="output">Вихідний список з виданими монетами</param>
        /// <param name="AllowSame">Якщо true - дозволити видати однією монетою</param>
        /// <returns>Повертає true, якщо розмін можливо здійснити</returns>
        bool Exchange(int SumLeft, List<int> output, bool AllowSame)
        {
            if (SumLeft == 0) return true;
            for (int i = 0; i < dignity.Length; i++)
                if (treasury.Contains(dignity[i]) && (SumLeft >= dignity[i]) && (AllowSame || (SumLeft > dignity[i])))
                {
                    treasury.Remove(dignity[i]);
                    if (Exchange(SumLeft - dignity[i], output, true))
                    {
                        output.Add(dignity[i]);
                        return true;
                    }
                    else treasury.Add(dignity[i]);
                }
            return false;
        }

        /// <summary>
        /// Генерувати випадкові вкидування монет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxGenerate_CheckedChanged(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                while (checkBoxGenerate.Checked)
                {
                    Put(dignity[new Random().Next(dignity.Length)]);
                    Thread.Sleep(20);
                }
                /* Чекати, пока звільниться доступ до казни, і опустити семафор */
                semaphore.WaitOne();
                // Вивести на форму наявність монет
                // Передбачається виконання в поточному процесі
                ShowTreasury();
                /* Підняти семафор */
                semaphore.Release();
            })).Start();
        }

        /// <summary>
        /// Зміна користувачем наявної кількості монет деякого номіналу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Чекати, пока звільниться доступ до казни, і опустити семафор
            semaphore.WaitOne();
            // Змінити кількість монет в скарбниці
            treasury.Clear();
            for (int i = 0; i < dignity.Length; i++)
                for (int j = 0; j < numerics[i].Value; j++)
                    treasury.Add(dignity[i]);
            // Підняти семафор
            semaphore.Release();
        }


        /// <summary>
        /// Виведення на форму інформаці щодо наявних монет в казні
        /// </summary>
        void ShowTreasury()
        {
            int[] values = new int[dignity.Length];
            foreach (int chink in treasury)
                for (int i = 0; i < dignity.Length; i++)
                    if (chink == dignity[i])
                    {
                        values[i]++;
                        break;
                    }
            BeginInvoke(new EventHandler(delegate
                {
                    for (int i = 0; i < dignity.Length; i++)
                    {
                        numerics[i].ValueChanged -= handler;
                        numerics[i].Value = values[i];
                        numerics[i].ValueChanged += handler;
                    }
                }));
        }

        /// <summary>
        /// Вихід з програми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAutomat_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkBoxGenerate.Checked = false;
        }
    }
}
