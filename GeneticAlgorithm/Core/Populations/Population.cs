using GeneticAlgorithm.Core.Individuals;

namespace GeneticAlgorithm.Core.Populations
{
    internal class Population : IPopulation
    {
        public int Count { get; }
        public IIndividual[] Individuals { get; }

        public Population(int count)
        {
            Count = count;
            Individuals = new IIndividual[count];
        }
    }
}
