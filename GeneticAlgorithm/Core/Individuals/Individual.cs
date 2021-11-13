using GeneticAlgorithm.Core.Items;
using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal class Individual : IIndividual
    {
        public int EvolutionaryFitness { get; set; }
        public int Weight { get; set; }
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
                individual = this;
                return false;
            }

            individual = Mutate();

            return true;
        }

        public IIndividual Mutate()
        {
            Random random = new();
            int chromosome = random.Next(Chromosomes.Length);
            bool[] mutatedChromosomes = new bool[Chromosomes.Length];
            Array.Copy(Chromosomes, mutatedChromosomes, Chromosomes.Length);
            mutatedChromosomes[chromosome] = !mutatedChromosomes[chromosome];

            return new Individual(mutatedChromosomes);
        }

        public IIndividual Crossingover(IIndividual parent)
        {
            Random random = new();
            IIndividual child = new Individual(new bool[Chromosomes.Length]);

            int index = random.Next(Chromosomes.Length);
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                if (i < index)
                {
                    child.Chromosomes[i] = Chromosomes[i];
                }
                else
                {
                    child.Chromosomes[i] = parent.Chromosomes[i];
                }
            }

            return child;
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

            if (weight <= maxWeight)
            {
                return true;
            }

            IsAlive = false;
            return false;
        }
    }
}
