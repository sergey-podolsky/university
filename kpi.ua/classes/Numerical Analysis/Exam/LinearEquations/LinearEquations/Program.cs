using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinearEquations
{
    class Program
    {
        static double[,] a = 
        {
            {-18, 7, -17, 5, 21},
            {12, 38, 18, 7, 114},
            {20, 1, 27, 5, 3},
            {22.5, 3, 22.5, 7.5, 9}
        };

        static double[] GaussMethod(double[,] a, int row)
        {
            double[] x; // roots array

            // If recursion is over then return array of single root
            if (row == a.GetUpperBound(0))
            {
                x = new double[a.GetLength(0)];
                x[row] = a[row, row + 1] / a[row, row];
                return x;
            }

            // Reduce roots count
            for (var i = row + 1; i < a.GetLength(0); i++)
            {
                var k = a[i, row] / a[row, row];
                for (var j = row; j < a.GetLength(1); j++)
                    a[i, j] -= a[row, j] * k;
            }

            // Get roots of submatrix
            x = GaussMethod(a, row + 1); // Call recursion

            // Get current root
            x[row] = a[row, a.GetUpperBound(1)];
            for (var j = row + 1; j < a.GetLength(0); j++)
                x[row] -= x[j] * a[row, j];
            x[row] /= a[row, row];

            // Return roots of current matrix
            return x;
        }

        static List<double> CompletePivoting(double[,] a)
        {
            // If recursion is over then return list of single root
            if (a.GetLength(0) == 1)
                return new List<double> { a[0, 1] / a[0, 0] };

            // Search maximum absolute element
            int iMax = 0, jMax = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    if (Math.Abs(a[i, j]) > Math.Abs(a[iMax, jMax]))
                    {
                        iMax = i;
                        jMax = j;
                    }

            // Get submatrix of current matrix without pivot
            double[,] b = new double[a.GetLength(0) - 1, a.GetLength(1) - 1];
            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    var k = a[i < iMax ? i : i + 1, jMax] / a[iMax, jMax];
                    b[i, j] = a[i < iMax ? i : i + 1, j < jMax ? j : j + 1] - a[iMax, j < jMax ? j : j + 1] * k;
                }

            // Get roots of submatrix
            List<double> x = CompletePivoting(b); // Call recursion

            // Get pivot root
            double root = a[iMax, a.GetUpperBound(1)];
            for (int j = 0; j < a.GetLength(0) - 1; j++)
                root -= a[iMax, j < jMax ? j : j + 1] * x[j];
            x.Insert(jMax, root / a[iMax, jMax]);

            // Return roots of current matrix
            return x;
        }

        static IEnumerable<double> GaussJordanMethod(double[,] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                // Divide current row by diagonal coefficient
                for (var j = i + 1; j < a.GetLength(1); j++)
                    a[i, j] /= a[i, i];

                // Eliminate diagonal coefficient from other rows
                for (var k = 0; k < a.GetLength(0) - 1; k++)
                    for (var j = i + 1; j < a.GetLength(1); j++)
                        a[k < i ? k : k + 1, j] -= a[i, j] * a[k < i ? k : k + 1, i];
            }

            // Return right-hand free coefficients
            for (var i = 0; i < a.GetLength(0); i++)
                yield return a[i, a.GetUpperBound(1)];
        }

        static double[] DirectIteration(double[,] a, double eps)
        {
            // Initial roots
            double[] x0, x = new double[a.GetLength(0)];
            for (var i = 0; i < a.GetLength(0); i++)
                x[i] = a[i, a.GetUpperBound(1)];
            do
            {
                x0 = (double[])x.Clone();
                // Evaluate each new more exact root
                for (var i = 0; i < a.GetLength(0); i++)
                {
                    x[i] = a[i, a.GetUpperBound(1)];
                    for (var j = 0; j < a.GetLength(0); j++)
                        if (i != j)
                            x[i] -= x0[j] * a[i, j];
                    x[i] /= a[i, i];
                }

                // Calculate error for each root
                for (var i = 0; i < x.Length; i++)
                    x0[i] = Math.Abs(x0[i] - x[i]);
            }
            while (x0.Max() > eps);
            return x;
        }

        static double[] GaussSeidelMethod(double[,] a, double eps)
        {
            double error;
            // Initial roots
            double[] x = new double[a.GetLength(0)];
            for (var i = 0; i < a.GetLength(0); i++)
                x[i] = a[i, a.GetUpperBound(1)];
            do
            {
                error = 0;
                // Evaluate each new more exact root
                for (var i = 0; i < a.GetLength(0); i++)
                {
                    // Store previous value of x[i]
                    var prevXi = x[i];
                    // Recalculate x[i]
                    x[i] = a[i, a.GetUpperBound(1)];
                    for (var j = 0; j < a.GetLength(0); j++)
                        if (i != j)
                            x[i] -= x[j] * a[i, j];
                    x[i] /= a[i, i];
                    // Calculate error
                    error = Math.Max(error, Math.Abs(prevXi - x[i]));
                }
            }
            while (error > eps);
            return x;
        }

        static void Main(string[] args)
        {
            IEnumerable<double> x = GaussMethod(a.Clone() as double[,], 0);
            foreach (var root in x)
                Console.WriteLine(root);

            x = CompletePivoting(a.Clone() as double[,]);
            foreach (var root in x)
                Console.WriteLine(root);

            x = GaussJordanMethod(a.Clone() as double[,]);
            foreach (var root in x)
                Console.WriteLine(root);

            x = DirectIteration(a.Clone() as double[,], 0.0001);
            foreach (var root in x)
                Console.WriteLine(root);

            x = GaussSeidelMethod(a.Clone() as double[,], 0.0001);
            foreach (var root in x)
                Console.WriteLine(root);
        }
    }
}
