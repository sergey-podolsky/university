using System;

class Program
{
    static double CompositeRectangleRule(Func<double, double> f, double a, double b, double eps)
    {
        var n = (int)(1 + 1 / Math.Sqrt(eps));
        double prevResult, nextResult = 0;
        do
        {
            prevResult = nextResult;
            nextResult = 0;
            double h = (b - a) / n;
            for (int i = 1; i < n; i++)
                nextResult += f(a + i * h);
            nextResult *= h;
            n *= 2;
        }
        while (Math.Abs(nextResult - prevResult) > eps);
        return nextResult;
    }

    static double CompositeTrapeziumRule(Func<double, double> f, double a, double b, double eps)
    {
        var n = (int)(1 / Math.Sqrt(eps));
        double prevResult, nextResult = 0;
        do
        {
            prevResult = nextResult;
            nextResult = (f(a) + f(b)) / 2;
            double h = (b - a) / n;
            for (int i = 1; i < n; i++)
                nextResult += f(a + i * h);
            nextResult *= h;
            n *= 2;
        }
        while (Math.Abs(nextResult - prevResult) / 3 > eps);
        return nextResult;
    }

    static double CompositeSimpsonsRule(Func<double, double> f, double a, double b, double eps)
    {
        var n = (int)(Math.Pow(eps, -0.25));
        n += n % 2;
        double prevResult, nextResult = 0;
        do
        {
            prevResult = nextResult;
            nextResult = f(a) + f(b);
            double h = (b - a) / n;
            for (int i = 1; i < n; i += 2)
                nextResult += 4 * f(a + i * h);
            for (int i = 2; i < n; i += 2)
                nextResult += 2 * f(a + i * h);
            nextResult *= h / 3;
            n *= 2;
        }
        while (Math.Abs(nextResult - prevResult) / 15 > eps);
        return nextResult;
    }


    static void Main(string[] args)
    {
        Console.WriteLine(CompositeRectangleRule(x => x * x, 0, 1, 0.001));
        Console.WriteLine(CompositeTrapeziumRule(x => x * x, 0, 1, 0.001));
        Console.WriteLine(CompositeSimpsonsRule(x => x * x, 0, 1, 0.001));
    }
}