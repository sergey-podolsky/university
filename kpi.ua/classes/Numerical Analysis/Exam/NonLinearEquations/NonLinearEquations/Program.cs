using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonLinearEquations
{
    class Program
    {
        static Func<double[], double>[] f = 
        {
            x => x[0] * x[0] + x[1] * x[1] + x[2] * x[2] - 1,
            x => 2 * x[0] * x[0] + x[1] * x[1] - 4 * x[2],
            x => 3 * x[0] * x[0] - 4 * x[1] + x[2] * x[2]
        };

        static Func<double[], double>[,] w = 
        {
            { x => 2 * x[0], x => 2 * x[1], x => 2 * x[2] },
            { x => 4 * x[0], x => 2 * x[1], x => -4 },
            { x => 6 * x[0], x => -4, x => 2 * x[2] }
        };

        public static double Det(double[,] matrix)
        {
            if (matrix.GetLength(0) == 1) return matrix[0, 0];
            if (matrix.GetLength(0) == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            double result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                result += matrix[i, 0] * Det(TruncateMatrix(matrix, i, 0)) * (i % 2 == 0 ? 1 : -1);
            return result;
        }

        private static double[,] TruncateMatrix(double[,] matrix, int row, int column)
        {
            double[,] subMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            for (int i = 0, m = 0; i < matrix.GetLength(0); i++)
                if (i != row)
                {
                    for (int j = 0, n = 0; j < matrix.GetLength(1); j++)
                        if (j != column)
                            subMatrix[m, n++] = matrix[i, j];
                    m++;
                }
            return subMatrix;
        }

        public static void Transpose(double[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
                for (int j = 0; j < i; j++)
                {
                    var tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
        }

        public static double[,] Inverse(double[,] matrix)
        {
            double det = Det(matrix);
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i,j] = Det(TruncateMatrix(matrix, i, j)) * (i + j % 2 == 0 ? 1 : -1) / det;
            Transpose(result);
            return result;
        }

        static void Main()
        {
            double[] X = { 0.5, 0.5, 0.5 };
            for (int k = 0; k < 100; k++)
            {
                double[] F = f.Select(func => func(X)).ToArray();

                double[,] W = new double[X.Length, X.Length];
                for (int i = 0; i < X.Length; i++)
                    for (int j = 0; j < f.Length; j++)
                        W[i, j] = w[i, j](X);
                W = Inverse(W);

                double[] X1 = new double[X.Length];
                for (int i = 0; i < X.Length; i++)
                {
                    X1[i] = X[i];
                    for (int j = 0; j < X.Length; j++)
                        X1[i] -= W[i, j] * X[j];
                }

                X = X1;
            }

            foreach (var x in X) Console.WriteLine(x);
        }
    }
}
