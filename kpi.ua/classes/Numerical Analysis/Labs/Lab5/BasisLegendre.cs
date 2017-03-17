using System;
using System.Collections.Generic;

namespace NumLab5
{
    class BasisLegendre : Basis
    {
        /// <summary>
        /// Stores specified number of Legendre's monomials
        /// Each monomial is stored as an array of it's coefficients
        /// </summary>
        List<double[]> monomials = new List<double[]>();

        /// <summary>
        /// Effective resizing of available element count
        /// </summary>
        /// <param name="newLength">New count of elements</param>
        public void Resize(int newLength)
        {
            if (newLength < 0) throw new Exception("Invalid length");
            if (newLength < monomials.Count)
                monomials.RemoveRange(newLength, monomials.Count - newLength);
            else if (newLength > monomials.Count)
                for (int n = monomials.Count; n < newLength; n++)
                {
                    if (n == 0) monomials.Add(new double[1] { 1 });
                    else if (n == 1) monomials.Add(new double[2] { 0, 1 });
                    else
                    {
                        monomials.Add(new double[n + 1]);
                        for (int i = 0; i < n; i++)
                        {
                            monomials[n][i + 1] = (2 * n - 1) / n * monomials[n - 1][i];
                            if (i < n - 1)
                                monomials[n][i] -= (n - 1) / n * monomials[n - 2][i];
                        }
                    }
                }
        }

        /// <summary>
        /// Get Legendre's monomial with number 'n'
        /// If 'n' is greater then available count => effective resizing is called.
        /// When object of this is created first time, available count equals zero.
        /// </summary>
        /// <param name="n">Number of element</param>
        /// <returns>Function that represent specified monomial</returns>
        public override Program.Function this[int n]
        {
            get
            {
                if (n < 0) throw new Exception("Invalid element index");
                if (n >= monomials.Count) Resize(n + 1);
                return delegate(double x)
                    {
                        double result = monomials[n][n];
                        for (int i = n - 1; i >= 0; i--)
                            result = result * x + monomials[n][i];
                        return result;
                    };
            }
        }
    }
}
