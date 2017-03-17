namespace NumLab5
{
    /// <summary>
    /// Reperesents basis to create monomials (parent class for others)
    /// </summary>
    abstract class Basis
    {
        public abstract Program.Function this[int n]
        {
            get;
        }
    }
}
