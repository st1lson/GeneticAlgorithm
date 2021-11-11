using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal interface IIndividual
    {
        public int EvolutionaryFitness { get; }
        public int NumberOfEvolutions { get; }
        public bool IsAlive { get; }
        public bool[] Chromosomes { get; }

        public bool TryMutate(Random random, double mutationChance, out IIndividual individual);
        public IIndividual Mutate(double mutationChance);

        public IIndividual[] Crossingover();

        public void LocalUpgrade();
    }
}
