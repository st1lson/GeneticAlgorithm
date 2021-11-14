using GeneticAlgorithm.Core.Items;
using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal interface IIndividual
    {
        public int EvolutionaryFitness { get; set; }
        public int Weight { get; set; }
        public bool IsAlive { get; set; }
        public int[] Chromosomes { get; }

        public bool TryMutate(Random random, double mutationChance, out IIndividual individual);
        public IIndividual FirstMutation();
        public IIndividual SecondMutation();

        public IIndividual[] SinglePointCrossingover(IIndividual parent);
        public IIndividual[] TwoPointCrossingover(IIndividual parent);
        public IIndividual[] UniformCrossingover(IIndividual parent, double crossingoverChance);

        public IIndividual FirstLocalUpgrade();
        public IIndividual SecondLocalUpgrade();
        public bool CheckWeight(int maxWeight, IItem[] items);
    }
}
