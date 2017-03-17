using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        /* * * * * * * * * * * * * * * * * *
         * Lagrange Interpolation
         * * * * * * * * * * * * * * * * * */
        LagrangeInterpolation(x => x * x, 0, 10, 0.1, new double[] { 1, 2, 3, 4, 5 });

        /* * * * * * * * * * * * * * * * * *
         * Aitken Scheme
         * * * * * * * * * * * * * * * * * */
        {
            var x = new List<double> { 0, 1, 2, 4, 5, 6 };
            var f = new List<double> { 0, 1, 4, 16, 25, 36 };

            double v = 3;
            double eps = 0.001;

            var fi = new List<List<double>> { f };

            do
            {
                fi.Add(new List<double>());
                for (var i = 1; i < fi.Count; i++)
                    fi[i].Add((fi[i - 1][fi.Count - i - 1] * (x[fi.Count - 1] - v) - fi[i - 1][fi.Count - i] * (x[fi.Count - i - 1] - v)) / (x[fi.Count - 1] - x[fi.Count - i - 1]));
            }
            while (fi.Count < f.Count && Math.Abs(fi.Last().First() - fi[fi.Count - 2].First()) > eps);

            Console.WriteLine(fi.Last()[0]);
        }
    }

    static void LagrangeInterpolation(Func<double, double> f, double a, double b, double eps, double[] checkPoints)
    {
        for (var n = 3; ; n++)
        {
            var h = (a + b) / n;
            var nodes = from i in Enumerable.Range(0, n) let x = a + i * h select new { X = x, Y = f(x) };
            var values = from checkPoint in checkPoints
                         select new
                         {
                             Exact = f(checkPoint),
                             Interpolated = nodes.Sum(Node => Node.Y * nodes.Aggregate(1.0, (p, node) => Node.X == node.X ? p : p * (checkPoint - node.X) / (Node.X - node.X)))
                         };
            if (values.All(value => Math.Abs(value.Exact - value.Interpolated) < eps))
            {
                foreach (var value in values)
                    Console.WriteLine(value.Interpolated);
                break;
            }
        }
    }
}