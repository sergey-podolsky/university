using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad
{
    /// <summary>
    /// ListBox with multiline items
    /// </summary>
    public partial class MultiLineListBox : ListBox
    {
        /// <summary>
        /// Measure item size
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Site == null && e.Index > -1)
            {
                SizeF sizeF = e.Graphics.MeasureString(Items[e.Index].ToString(), Font, Width);
                e.ItemHeight = (int)sizeF.Height;
                e.ItemWidth = (int)sizeF.Width;
            }
        }

        /// <summary>
        /// Draw item
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Site == null && e.Index > -1)
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(SystemColors.WindowText), e.Bounds);
                    e.Graphics.DrawRectangle(new Pen(SystemColors.Highlight), e.Bounds);
                }
                else
                {
                    SelectedIndex = e.Index;
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(SystemColors.HighlightText), e.Bounds);
                }
        }
    }
}

