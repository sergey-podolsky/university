using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Task1
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            // Create a new bitmap to take a screenshot with a size of screen
            bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // Create a Graphics object from bitmap to draw on it
            Graphics g = Graphics.FromImage(bitmap);
            // Take a screenshot of the screen an drow to bitmap
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            // Flip bitmap on Y axis
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            // Set a pictureBox source source to the bitmap
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// Button click event handler
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Flip bitmap vertically again
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            // Refresh image on picterBox 
            pictureBox1.Refresh();
        }
    }
}
