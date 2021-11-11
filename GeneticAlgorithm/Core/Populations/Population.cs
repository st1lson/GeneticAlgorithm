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

        public void InitializePopulation()
        {
            for (int i = 0; i < Count; i++)
            {
                Individuals[i] = new Individual(0);
            }
        }
    }
}
