using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal class Individual : IIndividual
    {
        public int NumberOfEvolutions { get; }
        public int EvolutionaryFitness { get; private set; }
        public bool IsAlive { get; private set; }
        public bool[] Chromosomes { get; }

        public Individual(bool[] chromosomes)
        {
            Chromosomes = chromosomes;
            NumberOfEvolutions = chromosomes.Length;
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

            individual = Mutate(mutationChance);

            return true;
        }

        public IIndividual Mutate(double mutationChance)
        {
            return default;
        }

        public IIndividual[] Crossingover()
        {
            return default;
        }

        public void LocalUpgrade()
        {

        }
    }
}
