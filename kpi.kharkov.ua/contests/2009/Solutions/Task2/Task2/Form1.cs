using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace Task2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool SystemParametersInfo(int uiAction, int uiParam, string pvParam, int fWinIni);

        const int SPI_GETDESKWALLPAPER = 0x73; // Does not work. Implemented via registry instead.
        const int SPI_SETDESKWALLPAPER = 20;

        const string newWallpaper = @"sample.bmp";
        string oldWallpaper;

        int secondsLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            label.Text = (secondsLeft = 10).ToString();
            // Get current wallpaper path
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                oldWallpaper = registryKey.GetValue("WallPaper").ToString();
            // Set new temporary wallpaper
            SystemParametersInfo(SPI_SETDESKWALLPAPER, newWallpaper.Length, newWallpaper, 0);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (--secondsLeft <= 0)
            {
                timer.Stop();
                label.Text = string.Empty;
                Console.Beep();
                // Restore previous wallpaper
                SystemParametersInfo(SPI_SETDESKWALLPAPER, oldWallpaper.Length, oldWallpaper, 0);
            }
            else label.Text = secondsLeft.ToString();
        }
    }
}
