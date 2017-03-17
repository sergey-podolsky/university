using System;

namespace NumLab5
{
    class BasisPolinomials : Basis
    {
        public override Program.Function this[int n]
        {
            get
            {
                return delegate(double x)
                    {
                        return Math.Pow(x, n);
                    };
            }
        }
    }
}
