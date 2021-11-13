using GeneticAlgorithm.Core.Individuals;
using System.Linq;

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

        public void Replace(IIndividual individual)
        {
            IIndividual[] individuals = Individuals.OrderByDescending(x => x.EvolutionaryFitness).ToArray();
            individuals[^1] = individual;
        }
    }
}
