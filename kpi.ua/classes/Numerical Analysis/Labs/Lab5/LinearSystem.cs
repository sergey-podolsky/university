using System;
using System.Collections.Generic;
using System.IO;

namespace NumLab5
{
    /// <summary>
    /// Contains methods to solve systems of linear equations
    /// </summary>
    static class LinearSystem
    {
        /// <summary>
        /// Functional type to store method to solve linear system
        /// </summary>
        /// <param name="matrix">Advanced matrix with right-hand side values</param>
        /// <returns>List of roots</returns>
        public delegate List<double> SolveMethod(double[,] matrix);

        /// <summary>
        /// Solve linear system using complete pivoting
        /// In this method list is used instead of array because we need to insert roots during recursion
        /// </summary>
        /// <param name="matrix">Advanced matrix with right-hand side values</param>
        /// <returns>List of roots according to an order of source matrix</returns>
        public static List<double> CompletePivoting(double[,] matrix)
        {
            // Current root count
            int size = matrix.GetLength(0);

            // If recursion is over then return list containing one root
            if (size == 1)
                return new List<double>(new double[] { matrix[0, 1] / matrix[0, 0] });

            // Search maximum absolute element
            int iMax = -1, jMax = -1;   // If program leaves these values then exception will be thrown
            double max = double.NegativeInfinity;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (Math.Abs(matrix[i, j]) > max)
                        max = Math.Abs(matrix[iMax = i, jMax = j]);

            // Get vector of coefficients to multiply and add for each row
            double[] m = new double[size - 1];
            for (int i = 0, k = 0; i < size; i++)
                if (i != iMax)
                    m[k++] = -matrix[i, jMax] / matrix[iMax, jMax];

            // Get submatrix of current matrix without pivot
            double[,] subMatrix = TruncateMatrix(matrix, size, size + 1, iMax, jMax);

            // Add pivot row to each row
            for (int i = 0; i < size - 1; i++)
                for (int j = 0, k = 0; j <= size; j++)
                    if (j != jMax)
                        subMatrix[i, k++] += m[i] * matrix[iMax, j];

            // Get roots of submatrix
            List<double> roots = CompletePivoting(subMatrix); // Call recursion

            // Get pivot root
            double root = matrix[iMax, size];
            for (int j = 0, k = 0; j < size; j++)
                if (j != jMax)
                    root -= matrix[iMax, j] * roots[k++];
            roots.Insert(jMax, root / matrix[iMax, jMax]);

            // Return roots of current matrix
            return roots;
        }

        /// <summary>
        /// Get new submatrix without specified row and column
        /// </summary>
        /// <param name="matrix">Two-dimension array</param>
        /// <param name="height">Height of source matrix</param>
        /// <param name="width">Width of source matrix</param>
        /// <param name="row">Row index to cut</param>
        /// <param name="column">Column index to cut</param>
        /// <returns></returns>
        private static double[,] TruncateMatrix(double[,] matrix, int height, int width, int row, int column)
        {
            double[,] subMatrix = new double[height - 1, width - 1];
            for (int i = 0, m = 0; i < height; i++)
                if (i != row)
                {
                    for (int j = 0, n = 0; j < width; j++)
                        if (j != column)
                            subMatrix[m, n++] = matrix[i, j];
                    m++;
                }
            return subMatrix;
        }

        /// <summary>
        /// Get determinant
        /// </summary>
        /// <param name="matrix">Two-dimension array</param>
        /// <param name="size">Size of matrix</param>
        /// <returns>Determinant value</returns>
        public static double Det(double[,] matrix, int size)
        {
            if (Math.Min(matrix.GetLength(0), matrix.GetLength(1)) < size) throw new Exception("Invalid matrix size");
            if (size == 1) return matrix[0, 0];
            if (size == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            double result = 0;
            for (int j = 0; j < size; j++)
                result += matrix[0, j] * Det(TruncateMatrix(matrix, size, size, 0, j), size - 1) * (j % 2 == 0 ? 1 : -1);
            return result;
        }

        /// <summary>
        /// Print matrix
        /// </summary>
        /// <param name="matrix">Two-dimension array</param>
        public static void PrintMatrix(double[,] matrix, TextWriter stream)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    stream.Write("{0:0.##}\t", matrix[i, j]);
                stream.WriteLine();
            }
            for (int i = 0; i < 80; i++)    // Print line-separator
                stream.Write('_');
            Console.WriteLine();
        }
    }
}
