using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Homework10
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static double[][] Matrix { get; set; }

        /// <summary>
        /// If this value is false the we will look for maximum among minima
        /// Else we will look for minimum among maxima
        /// </summary>
        internal static bool Invert { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (e.Args.Length > 0)
                {
                    // Parese input text file into double[][] jagged array
                    using (var file = File.OpenText(e.Args.First()))
                        Matrix = (from line in file.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                  select (
                                      from str in line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                      select Convert.ToDouble(str)).ToArray()
                            ).ToArray();

                    ValidateMatrix(Matrix);

                    // Transpone input matrix from 2xN to Nx2
                    if (Matrix.Length == 2)
                    {
                        Matrix = Matrix.First().Zip(Matrix.Last(), (first, last) => new[] { first, last }).ToArray();
                    }
                    else
                        Invert = true;
                }
                else throw new Exception("Input file name is not specified as application argument.\nPlease run application from command line with input matrix file name as argument");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        static void ValidateMatrix(double[][] Matrix)
        {
            if (Matrix.Length != 2 && Matrix.First().Length != 2
                || Matrix.Length == 2 && Matrix.First().Length != Matrix.Last().Length
                || Matrix.Length != 2 && Matrix.Any(row => row.Length != 2))
                throw new Exception("Only 2xN or Nx2 matrices are allowed");
        }
    }
}