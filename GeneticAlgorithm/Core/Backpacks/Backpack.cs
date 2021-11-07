using System.Collections.Generic;
using GeneticAlgorithm.Core.Items;

namespace GeneticAlgorithm.Core.Backpacks
{
    internal class Backpack : IBackpack
    {
        public int MaxWeight { get; }
        public int CurrentWeight { get; }
        public List<IItem> Items { get; }
    }
}
