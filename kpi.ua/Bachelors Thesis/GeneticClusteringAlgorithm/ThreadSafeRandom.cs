using System;

namespace GeneticClusteringAlgorithm
{
    public class ThreadSafeRandom : Random
    {
        public override int Next()
        {
            lock (this)
                return base.Next();
        }

        public override int Next(int maxValue)
        {
            lock (this)
                return base.Next(maxValue);
        }

        public override int Next(int minValue, int maxValue)
        {
            lock (this)
                return base.Next(minValue, maxValue);
        }

        public override double NextDouble()
        {
            lock (this)
                return base.NextDouble();
        }
    }
}
