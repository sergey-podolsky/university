using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MemoryMapper
{
    public partial class FormMemoryMapper : Form
    {
        const string none = "<нема>";

        int size = 0;

        public FormMemoryMapper()
        {
            InitializeComponent();
            numericUpDownSectionNumber.Maximum = numericUpDownSectionOffset.Maximum = numericUpDownSectionSize.Maximum = numericUpDownProcessNumber.Maximum = numericUpDownProcessSize.Maximum = decimal.MaxValue;
            buttonAddSection_Click(null, null);
        }

        private void buttonAddSection_Click(object sender, EventArgs e)
        {
            dataGridViewSections.Rows.Add(numericUpDownSectionNumber.Value++, numericUpDownSectionOffset.Value, numericUpDownSectionSize.Value, none, 0);
            textBoxMemory.Text = (numericUpDownSectionOffset.Value = size += Convert.ToInt32(numericUpDownSectionSize.Value)).ToString();
            Add();
        }

        private void buttonAddProcess_Click(object sender, EventArgs e)
        {
            dataGridViewQueue.Rows.Add(numericUpDownProcessNumber.Value++, numericUpDownProcessSize.Value);
            Add();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = dataGridViewSections.SelectedRows[0].Cells;
            cells[ColumnProcess.Name].Value = none;
            cells[ColumnMemoryUsed.Name].Value = 0;
            Add();
            dataGridViewSections_SelectionChanged(null, null);
        }

        private void dataGridViewSections_SelectionChanged(object sender, EventArgs e)
        {
            buttonClear.Enabled = (dataGridViewSections.SelectedRows.Count > 0) && (Convert.ToInt32(dataGridViewSections.SelectedRows[0].Cells[ColumnMemoryUsed.Name].Value) != 0);
            area.Invalidate();
        }

        void Add()
        {
            foreach (DataGridViewRow process in dataGridViewQueue.Rows)
                foreach (DataGridViewRow section in dataGridViewSections.Rows)
                    if ((Convert.ToInt32(section.Cells[ColumnMemoryUsed.Name].Value) == 0) && (Convert.ToInt32(section.Cells[ColumnSectionSize.Name].Value) >= Convert.ToInt32(process.Cells[ColumnProcessSize.Name].Value)))
                    {
                        section.Cells[ColumnProcess.Name].Value = process.Cells[ColumnProcessNumber.Name].Value;
                        section.Cells[ColumnMemoryUsed.Name].Value = process.Cells[ColumnProcessSize.Name].Value;
                        dataGridViewQueue.Rows.Remove(process);
                        dataGridViewSections_SelectionChanged(null, null);
                        area.Invalidate();
                        return;
                    }
            area.Invalidate();
        }

        private void labelArea_Paint(object sender, PaintEventArgs e)
        {
            double scale = (double)area.Height / (double)size;
            for (int section = 0; section < dataGridViewSections.Rows.Count; section++)
            {
                int sectionOffset = Convert.ToInt32(dataGridViewSections.Rows[section].Cells[ColumnOffset.Name].Value);
                int sectionSize = Convert.ToInt32(dataGridViewSections.Rows[section].Cells[ColumnSectionSize.Name].Value);
                int memoryUsed = Convert.ToInt32(dataGridViewSections.Rows[section].Cells[ColumnMemoryUsed.Name].Value);

                Rectangle sectionRectangle = new Rectangle(0, (int)(scale * sectionOffset), area.Width, (int)(scale * sectionSize));
                Rectangle processRectangle = new Rectangle(0, (int)(scale * sectionOffset), area.Width, (int)(scale * memoryUsed));
                e.Graphics.FillRectangle(Brushes.White, sectionRectangle);
                e.Graphics.FillRectangle(Brushes.Aquamarine, processRectangle);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), sectionRectangle);

                if (section == dataGridViewSections.SelectedRows[0].Index)
                    e.Graphics.FillRectangle(new System.Drawing.Drawing2D.HatchBrush(HatchStyle.DottedDiamond, Color.Gray, Color.Transparent), sectionRectangle);
                if (memoryUsed > 0)
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("Процес " + dataGridViewSections.Rows[section].Cells[ColumnProcess.Name].Value.ToString(), new Font("Times New Roman", 10), Brushes.Black, processRectangle, stringFormat);
                }

                if (sectionRectangle.Contains(mouse))
                {
                    string s = "Розділ " + section.ToString() + "\n" + "Адреса розілу: " + sectionOffset.ToString() + "\n\n";
                    if (processRectangle.Contains(mouse))
                    {
                        int physicalOffset = (int)((double)mouse.Y / scale);
                        int virtualOffset = physicalOffset - sectionOffset;
                        s += "Процес " + dataGridViewSections.Rows[section].Cells[ColumnProcess.Name].Value.ToString() + "\n";
                        s += "Віртуальна адреса: " + virtualOffset.ToString() + "\n";
                        s += "Фізична адреса: " + virtualOffset.ToString() + "+" + sectionOffset.ToString() + "=" + physicalOffset.ToString();
                    }
                    else s += "Вільна область пам'яті";
                    toolTip.Show(s, area, mouse);
                    Pen pen = new Pen(Color.Red, 2);
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawLine(pen, 0, mouse.Y, Width, mouse.Y);
                }
            }
        }

        Point mouse = new Point(-1, -1);

        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            area.Invalidate();
        }

        private void перезапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
