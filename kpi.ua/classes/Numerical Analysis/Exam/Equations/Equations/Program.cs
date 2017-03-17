using System;

class Program
{
    static double BisectionMethod(Func<double, double> f, double a, double b, double eps)
    {
        double x = (a + b) / 2;
        while (b - a > 2 * eps)
        {
            if (f(a) * f(x) < 0) b = x;
            else a = x;
            x = (a + b) / 2;
        }
        return x;
    }

    static double MethodOfSuccessiveApproximations(Func<double, double> f, Func<double, double> df, double a, double b, double eps)
    {
        int sign = Math.Sign(df(a));
        double m1 = Math.Min(sign * df(a), sign * df(b));
        double M1 = Math.Max(sign * df(a), sign * df(b));
        double q = 1 - m1 / M1;
        eps = (1 - q) / q * eps;
        double x0, x1 = (a + b) / 2;
        do
            x1 = x1 - sign * f(x0 = x1) / M1;
        while (Math.Abs(x0 - x1) > eps);
        return x1;
    }

    static double ChordMethod(Func<double, double> f, Func<double, double> df, Func<double, double> d2f, double a, double b, double eps)
    {
        double c, x;
        if (d2f(a) * f(a) > 0)
        {
            c = a;
            x = b;
        }
        else
        {
            c = b;
            x = a;
        }
        double m1 = Math.Min(Math.Abs(df(a)), Math.Abs(df(b)));
        while (Math.Abs(f(x)) / m1 > eps)
            x = x - f(x) * (x - c) / (f(x) - f(c));
        return x;
    }

    static double NewtonRaphsonMethod(Func<double, double> f, Func<double, double> df, Func<double, double> d2f, double a, double b, double eps)
    {
        double x = d2f(a) * f(a) > 0 ? a : b;
        double m1 = Math.Min(Math.Abs(df(a)), Math.Abs(df(b)));
        while (Math.Abs(f(x)) / m1 > eps)
            x = x - f(x) / df(x);
        return x;
    }

    static void Main()
    {
        Console.WriteLine(BisectionMethod(x => 15 / x - x * x + 15, -1.5, -0.5, 0.001));
        Console.WriteLine(MethodOfSuccessiveApproximations(x => 15 / x - x * x + 15, x => -15 / (x * x) - 2 * x, -1.5, -0.5, 0.001));
        Console.WriteLine(ChordMethod(x => 15 / x - x * x + 15, x => -15 / (x * x) - 2 * x, x => 30 / (x * x * x) - 2, -1.5, -0.5, 0.001));
        Console.WriteLine(NewtonRaphsonMethod(x => 15 / x - x * x + 15, x => -15 / (x * x) - 2 * x, x => 30 / (x * x * x) - 2, -1.5, -0.5, 0.001));
    }
}
