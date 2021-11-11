using GeneticAlgorithm.Core.Items;
using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal class Individual : IIndividual
    {
        public double EvolutionaryFitness { get; set; }
        public bool IsAlive { get; set; }
        public bool[] Chromosomes { get; }

        public Individual(bool[] chromosomes)
        {
            Chromosomes = chromosomes;
            IsAlive = true;
        }

        public bool TryMutate(Random random, double mutationChance, out IIndividual individual)
        {
            double chance = random.NextDouble();
            if (mutationChance < chance)
            {
                individual = null;
                return false;
            }

            individual = Mutate();

            return true;
        }

        public IIndividual Mutate()
        {
            Random random = new();
            int chromosome = random.Next(Chromosomes.Length);
            Chromosomes[chromosome] = !Chromosomes[chromosome];

            return default;
        }

        public IIndividual[] Crossingover()
        {
            return default;
        }

        public void LocalUpgrade()
        {

        }

        public bool CheckWeight(int maxWeight, IItem[] items)
        {
            double weight = 0;
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                if (Chromosomes[i])
                {
                    weight += items[i].Weight;
                }
            }

            if (weight > maxWeight)
            {
                IsAlive = false;
                return false;
            }

            return true;
        }
    }
}
