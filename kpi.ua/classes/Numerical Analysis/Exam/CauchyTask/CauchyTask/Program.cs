using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<KeyValuePair<double, double>> EulerMethod(Func<double, double, double> f, double x0, double y0, double l, double eps)
    {
        List<KeyValuePair<double, double>> points;
        double x, y = double.PositiveInfinity, yPrev;
        var h = eps;
        do
        {
            yPrev = y;
            points = new List<KeyValuePair<double, double>> { new KeyValuePair<double, double>(x = x0, y = y0) };
            while (x < x0 + l)
            {
                y = y + h * f(x, y);
                x += h;
                points.Add(new KeyValuePair<double, double>(x, y));
            }
            h /= 2;
        }
        while (Math.Abs(yPrev - y) < eps);
        return points;
    }

    static List<KeyValuePair<double, double>> ImprovedEulerMethod(Func<double, double, double> f, double x0, double y0, double l, double eps)
    {
        List<KeyValuePair<double, double>> points;
        double x, y = double.PositiveInfinity, yPrev;
        var h = Math.Sqrt(eps);
        do
        {
            yPrev = y;
            points = new List<KeyValuePair<double, double>> { new KeyValuePair<double, double>(x = x0, y = y0) };
            while (x < x0 + l)
            {
                var y_ = y + h / 2 * f(x, y);
                y = y + h * f(x + h / 2, y_);
                x += h;
                points.Add(new KeyValuePair<double, double>(x, y));
            }
            h /= 2;
        }
        while (Math.Abs(yPrev - y) / 3 < eps);
        return points;
    }

    static List<KeyValuePair<double, double>> RungeMethod(Func<double, double, double> f, double x0, double y0, double l, double eps)
    {
        List<KeyValuePair<double, double>> points;
        double x, y = double.PositiveInfinity, yPrev;
        double h = Math.Pow(eps, 0.25);
        do
        {
            yPrev = y;
            points = new List<KeyValuePair<double, double>> { new KeyValuePair<double, double>(x = x0, y = y0) };
            while (x < x0 + l)
            {
                var k1 = h * f(x, y);
                var k2 = h * f(x + h / 2, y + k1 / 2);
                var k3 = h * f(x + h / 2, y + k2 / 2);
                var k4 = h * f(x + h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                x += h;
                points.Add(new KeyValuePair<double, double>(x, y));
            }
            h /= 2;
        }
        while (Math.Abs(yPrev - y) / 15 < eps);
        return points;
    }

    static void Main(string[] args)
    {
        var points = EulerMethod((x, y) => y - 2 * x / y, 0, 1, 10, 0.01);
        using (var stream = File.CreateText("../../../Euler.txt"))
            foreach (var point in points)
                stream.WriteLine("{0}; {1}", point.Key, point.Value);

        points = ImprovedEulerMethod((x, y) => y - 2 * x / y, 0, 1, 10, 0.01);
        using (var stream = File.CreateText("../../../ModifiedEuler.txt"))
            foreach (var point in points)
                stream.WriteLine("{0}; {1}", point.Key, point.Value);

        points = RungeMethod((x, y) => y - 2 * x / y, 0, 1, 10, 0.01);
        using (var stream = File.CreateText("../../../Runge.txt"))
            foreach (var point in points)
                stream.WriteLine("{0}; {1}", point.Key, point.Value);
    }
}

