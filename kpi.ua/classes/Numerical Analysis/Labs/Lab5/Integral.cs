using System;

namespace NumLab5
{
    /// <summary>
    /// Numerical integration class
    /// </summary>
    static class Integral
    {
        /// <summary>
        /// Functional type to store integral rule
        /// </summary>
        /// <param name="f">Integrand</param>
        /// <param name="a">Lower bound</param>
        /// <param name="b">Upper bound</param>
        /// <param name="eps">Error</param>
        /// <returns>Result</returns>
        public delegate double Rule(Program.Function f, double a, double b, double eps);


        /// <summary>
        /// Get definite integral using composite trapezium rule
        /// </summary>
        /// <param name="f">Integrand</param>
        /// <param name="a">Lower bound</param>
        /// <param name="b">Upper bound</param>
        /// <param name="eps">Error</param>
        /// <returns>Result</returns>
        public static double CompositeTrapeziumRule(Program.Function f, double a, double b, double eps)
        {
            if (b < a) throw new Exception("Upper integral bound is less than lower");
            if (a == b) return 0;
            
            // (?) All the program works only with constant numper of integral steps
            double n = 200; // 1 + 1 / math.Sqrt(eps);
            double bounds = (f(a) + f(b)) / 2;
            double prevResult, nextResult = 0;
            do
            {
                prevResult = nextResult;
                nextResult = bounds;
                double h = (b - a) / n;
                for (int i = 1; i < n; i++) nextResult += f(a + i * h);
                nextResult *= h;
                n *= 2;
            }
            //while (Math.Abs(nextResult - prevResult) > eps); /* Uncomment this and comment line below to use error checking */
            while (false); 
            return nextResult;
        }
    }
}
