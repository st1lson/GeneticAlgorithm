using GeneticAlgorithm.Core.Individuals;

namespace GeneticAlgorithm.Core.Populations
{
    internal interface IPopulation
    {
        public int Count { get; }
        public IIndividual[] Individuals { get; }

        public void Replace(IIndividual oldIndividual, IIndividual newIndividual);
    }
}
