using GeneticAlgorithm.Core.Individuals;
using System;

namespace GeneticAlgorithm.Core.Populations
{
    internal class Population : IPopulation
    {
        public int Count { get; }
        public IIndividual[] Individuals { get; private set; }

        public Population(int count)
        {
            Count = count;
            Individuals = new IIndividual[count];
        }

        public void Replace(IIndividual oldIndividual, IIndividual newIndividual)
        {
            int index = Array.IndexOf(Individuals, oldIndividual);
            Individuals[index] = newIndividual;
        }
    }
}
