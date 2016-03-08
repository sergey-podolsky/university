using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Visifire.Charts;
using Visifire.Commons;

namespace ConflictProbabilities
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        /// <summary>
        /// Count of experiments per each probability point calcilation
        /// </summary>
        const int experiments = 300;

        /// <summary>
        /// Probability increment to go ahead from 0.01 to 1.0
        /// </summary>
        const double percentStep = 0.03;

        /// <summary>
        /// Show form
        /// </summary>
        public WindowMain()
        {
            InitializeComponent();
            // Create Y axis
            Axis yAxis = new Axis();
            yAxis.AxisMaximum = 1;
            yAxis.Title = "Probability";
            chart.AxesY.Add(yAxis);
            // Create X axis
            Axis xAxis = new Axis();
            //xAxis.AxisMaximum = 100;
            xAxis.Title = "% (percent)";
            chart.AxesX.Add(xAxis);
        }

        /// <summary>
        /// Regresh chart
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            chart.Series.Clear();
            // Create series for each matrix size
            for (int size = 10; size <= 30; size += 5)
            {
                // Prepare series
                DataSeries series = new DataSeries();
                series.RenderAs = RenderAs.Line;
                series.ShowInLegend = true;
                series.LegendText = size.ToString();
                series.LineThickness = 2;

                // Get total count of cells in square matrix
                int cellCount = size * size;
                // Fill matrix with different percent of "zero" cells (from 1% to 100%)
                for (double arcPercent = 0.01; arcPercent <= 1; arcPercent += percentStep)
                {
                    // Calculate statistics of conflicts for all experiments
                    double conflicts = 0;
                    for (int experiment = 0; experiment < experiments; experiment++)
                        if (Matrix.HasConflict(Matrix.RandomMatrix(size, (int)(arcPercent * cellCount))))
                            conflicts++;
                    // Plot point (add to series)
                    DataPoint point = new DataPoint();
                    point.XValue = arcPercent * 100;
                    point.YValue = conflicts / experiments;
                    series.DataPoints.Add(point);
                }
                chart.Series.Add(series);
            }
        }
    }
}
