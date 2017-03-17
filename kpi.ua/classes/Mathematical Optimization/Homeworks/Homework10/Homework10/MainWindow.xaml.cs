using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Homework10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point solution;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Solution search

            // All intersection points
            var points =
                from line1 in App.Matrix
                from line2 in App.Matrix
                where (line1[0] - line2[0]) * (line1[1] - line2[1]) < 0
                let denumerator = line1[0] - line1[1] - line2[0] + line2[1]
                select new Point((line1[0] - line2[0]) / denumerator, (line1[0] * line2[1] - line1[1] * line2[0]) / denumerator);

            // All line endpoints
            points = points.Union(App.Matrix.SelectMany(line => new[] { new Point(0, line[0]), new Point(1, line[1]) }));

            // Solution point
            solution = (from point in points
                        where App.Matrix.All(line => point.Y < line[0] + (line[1] - line[0]) * point.X ^ App.Invert || point.Y == line[0] + (line[1] - line[0]) * point.X)
                        select point
                            ).Aggregate((accumulator, next) => next.Y > accumulator.Y ^ App.Invert ? next : accumulator);

            #endregion

            #region GUI

            var max = App.Matrix.Max(row => row.Max());

            // Draw blue lines
            foreach (var column in App.Matrix)
            {
                var line = new Line { Stroke = Brushes.Blue };
                line.SetBinding(Line.X2Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualWidth") });
                line.SetBinding(Line.Y1Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualHeight"), Converter = new ScaledConverter(column[0] / max) });
                line.SetBinding(Line.Y2Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualHeight"), Converter = new ScaledConverter(column[1] / max) });
                canvas.Children.Add(line);
            }

            textBlockMaxLeft.Text = textBlockMaxRight.Text = max.ToString();

            // Draw dashed line
            var dashedLine = new Line { Stroke = Brushes.Black, StrokeDashArray = new DoubleCollection(new[] { 4.0, 1.0 }) };
            dashedLine.SetBinding(Line.X1Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualWidth"), Converter = new ScaledConverter(solution.X) });
            dashedLine.SetBinding(Line.X2Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualWidth"), Converter = new ScaledConverter(solution.X) });
            dashedLine.SetBinding(Line.Y2Property, new Binding { ElementName = canvas.Name, Path = new PropertyPath("ActualHeight"), Converter = new ScaledConverter(solution.Y / max) });
            canvas.Children.Add(dashedLine);

            // P1 and P2 TextBlocks
            textBlockP1.Inlines.Add(solution.X.ToString("0.###"));
            textBlockP2.Inlines.Add((1 - solution.X).ToString("0.###"));
            UpdateP();

            #endregion
        }

        /// <summary>
        /// Update labels P1=... and P2=...
        /// </summary>
        void UpdateP()
        {
            textBlockP1.Margin = new Thickness(Math.Max(0, (canvas.ActualWidth * solution.X - textBlockP1.ActualWidth) / 2), 0, 0, 0);
            textBlockP2.Margin = new Thickness(0, 0, Math.Max(0, (canvas.ActualWidth * (1 - solution.X) - textBlockP2.ActualWidth) / 2), 0);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateP();
        }
    }

    [ValueConversion(typeof(double), typeof(double))]
    class ScaledConverter : IValueConverter
    {
        double scale;

        public ScaledConverter(double scale)
        {
            this.scale = scale;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value * scale;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value / scale;
        }
    }
}