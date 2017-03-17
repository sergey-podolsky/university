using System;
using System.Collections.Generic;

namespace NumLab5
{
    class Polinomial
    {
        double[] coefficients;      // Polinomial coefficiends
        Basis basis;                // Basis to use
        Integral.Rule integralRule; // Rule to use for integration
        Program.Function function;  // Function to approximate
        double A;                   // Lower bound of interval
        double B;                   // Upper bound of interval


        /// <summary>
        /// Create polinomial instance
        /// </summary>
        /// <param name="f">Function to approximate</param>
        /// <param name="basisFunctions">Basis to use</param>
        /// <param name="rule">Rule to use for integration</param>
        /// <param name="solveMethod">Method to solve linear system</param>
        /// <param name="a">Lower bound of interval</param>
        /// <param name="b">Upper bound of interval</param>
        /// <param name="degree">Polinomial degree</param>
        public Polinomial(Program.Function f, Basis basisFunctions, Integral.Rule rule, LinearSystem.SolveMethod solveMethod, double a, double b, int degree)
        {
            // Initialize fields
            function = f;
            basis = basisFunctions;
            integralRule = rule;
            A = a;
            B = b;

            // Fill matrix with integrals - bind linear system
            double[,] matrix = new double[degree, degree + 1];
            for (int i = 0; i < degree; i++)
                for (int j = i; j <= degree; j++)
                    if (j < degree)
                        matrix[i, j] = matrix[j, i] = rule(
                        delegate(double t)
                        {
                            return basis[i](t) * basis[j](t);
                        }
                    , -1, 1, 0.001);
                    else
                        matrix[i, j] = rule(
                        delegate(double t)
                        {
                            return basis[i](t) * f((b + a) / 2 + t * (b - a) / 2);
                        }
                        , -1, 1, 0.001);

            // Solve linear system
            coefficients = solveMethod(matrix).ToArray();
        }


        /// <summary>
        /// Evaluate value using current polinomial object in point X
        /// </summary>
        /// <param name="x">Point to approximate</param>
        /// <returns>Approximated value</returns>
        public double Evaluate(double x)
        {
            double result = 0;
            for (int i = 0; i < coefficients.Length; i++)
                result += coefficients[i] * basis[i]((2 * x - B - A) / (B - A));
            return result;
        }


        /// <summary>
        /// Get least square deviation using numerical integration
        /// </summary>
        /// <returns>Deviation value</returns>
        public double LeastSquaresDeviation()
        {
            return Math.Sqrt(integralRule(
                delegate(double x)
                {
                    return Math.Pow(this.Evaluate(x) - function(x), 2);
                }, A, B, 0.001) / (B - A));
        }
    }
}
