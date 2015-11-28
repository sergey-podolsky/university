using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GeneticClusteringAlgorithm.Properties;
using System;

namespace GeneticClusteringAlgorithm
{
    public class GA
    {
        public static readonly ThreadSafeRandom random = new ThreadSafeRandom();

        // GA presets
        const double elitismRate = 0.05;
        const double MutationRate = 0.5;
        const int populationSize = 1024;

        // Locals     
        readonly Point[] points;
        readonly IEnumerable<int> indexArray;
        readonly int clusterSize;
        ConcurrentDictionary<IEnumerable<int>, double> population;

        public GA(Point[] points, int clusterSize)
        {
            // Assign locals
            this.points = points;
            this.clusterSize = clusterSize;
            indexArray = ParallelEnumerable.Range(0, points.Length);
            // Create initial population with random chromosomes. All generated chromosomes always cover all points. It means that there are all points in initial population.
            population = new ConcurrentDictionary<IEnumerable<int>, double>(InitialPopulation().ToDictionary(chromosome => chromosome, chromosome => Fitness(chromosome)));
        }

        IEnumerable<IEnumerable<int>> InitialPopulation()
        {
            var allAlleles = new List<int>();
            for (var i = 0; i < populationSize; i++)
            {
                if (allAlleles.Count < clusterSize)
                    allAlleles = ParallelEnumerable.Range(0, points.Length).OrderBy(_ => random.Next()).ToList();
                yield return allAlleles.Take((int)clusterSize).ToArray();
                allAlleles.RemoveRange(0, (int)clusterSize);
            }
        }

        double Fitness(IEnumerable<int> chromosome)
        {
            var center = new Point((int)chromosome.Average(allele => points[allele].X), (int)chromosome.Average(allele => points[allele].Y));
            return 1.0 / chromosome.Sum(allele => FormMain.Distance(points[allele], center));
        }

        static IEnumerable<int[]> Crossover(IEnumerable<int> father, IEnumerable<int> mother)
        {
            IEnumerable<int>
                intersect = father.Intersect(mother), motherRest = mother.Except(intersect), fatherRest = father.Except(intersect);
            int motherRestHalfSize = motherRest.Count() / 2, fatherRestRestHalfSize = fatherRest.Count() / 2;
            yield return intersect.Concat(motherRest.Take(motherRestHalfSize)).Concat(fatherRest.Skip(fatherRestRestHalfSize)).ToArray();
            yield return intersect.Concat(motherRest.Skip(motherRestHalfSize)).Concat(fatherRest.Take(fatherRestRestHalfSize)).ToArray();
        }

        IEnumerable<int> Mutation(int[] chromosome)
        {
            if (points.Length > chromosome.Length && random.NextDouble() <= MutationRate)
                chromosome[random.Next(chromosome.Length)] = indexArray.Except(chromosome).ElementAt(random.Next(points.Length - chromosome.Length));
            return chromosome;
        }

        public KeyValuePair<IEnumerable<int>, double> Reproduction()
        {
            // Normalize, accumulate and order fitness by descending
            var fitnessSum = population.Sum(pair => pair.Value);
            var accumulator = 0.0;
            var roulette = (from pair in population orderby pair.Value descending select new { Chromosome = pair.Key, Fitness = pair.Value, AccumulatudFitness = (accumulator += pair.Value / fitnessSum) }).ToArray();
            // Count of children pairs to be produced
            var childrenPairs = (int)(populationSize * (1 - elitismRate) / 2);
            // Take count of elite chromosomes
            population = new ConcurrentDictionary<IEnumerable<int>, double>(roulette.Take(populationSize - childrenPairs * 2).ToDictionary(pair => pair.Chromosome, pair => pair.Fitness));
            // Produce children and fill population with them
            Parallel.For(0, childrenPairs, _ =>
            {
                foreach (var child in from chromosome in Crossover(roulette.First(pair => pair.AccumulatudFitness >= random.NextDouble()).Chromosome, roulette.First(pair => pair.AccumulatudFitness >= random.NextDouble()).Chromosome) select Mutation(chromosome))
                    population[child] = Fitness(child);
            });
            // Return fittest cluster 
            return population.Aggregate((max, next) => next.Value > max.Value ? next : max);
        }
    }
}
