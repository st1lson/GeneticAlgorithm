using GeneticAlgorithm.Core.Individuals;
using GeneticAlgorithm.Core.Items;
using System.Collections.Generic;

namespace GeneticAlgorithm.Core
{
    internal interface IBackpack
    {
        public int MaxWeight { get; }
        public List<IItem> Items { get; }

        public void Solve(IIndividual individual);
    }
}
