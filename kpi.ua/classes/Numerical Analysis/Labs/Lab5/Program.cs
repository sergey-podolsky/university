using System;
using System.IO;

namespace NumLab5
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        // Function to approximate
        static double function(double x)
        {
            return 0.5 * Math.Pow(x, 3) * Math.Sin(3 * x);  
            // return 1 / (1 + 25 * x * x);
        }

        const double a = 0.0;   // Lower function bound
        const double b = 5.7;   // Upper function bound
        static int degree = 10; // Starting polinomial degree

        static readonly Basis basis = new BasisChebyshev();
        //static readonly Basis basis = new BasisLegendre();
        //static readonly Basis basis = new BasisPolinomials();

        static readonly Integral.Rule integralRule = Integral.CompositeTrapeziumRule;
        static readonly LinearSystem.SolveMethod solveMethod = LinearSystem.CompletePivoting;



        /* =============== Application entry point =============== */
        static void Main(string[] args)
        {
            // Create sequentially new polinomial object until specified least squares deviation is reached
            Polinomial polinomial;
            double deviation;
            do
            {
                Console.Write("Polinomial degree:\t{0}", degree);
                polinomial = new Polinomial(function, basis, integralRule, solveMethod, a, b, degree++);
                deviation = polinomial.LeastSquaresDeviation();
                Console.WriteLine("\tLeast squares deviation:\t{0:0.############}", deviation);
            }
            while (deviation > 0.001);
            // while (false) // Uncomment this and comment line above to create one polinom

            // Write results to files
            const string fPath = "F.txt", pPath = "P.txt";
            using (TextWriter f = File.CreateText("F.txt"), p = File.CreateText("P.txt"))
            {
                double x = a, h = (b - a) / 100;
                while (x <= b)
                {
                    f.WriteLine("{0}; {1}", x, function(x));
                    p.WriteLine("{0}; {1}", x, polinomial.Evaluate(x));
                    x += h;
                }
            }
            Console.WriteLine("Look for results in files '{0}', '{1}'.", fPath, pPath);
            //Console.ReadKey();
        }


        /// <summary>
        /// Functional type to store and pass methods
        /// </summary>
        /// <param name="x">Function parameter</param>
        /// <returns>Function value</returns>
        public delegate double Function(double x);
    }
}
