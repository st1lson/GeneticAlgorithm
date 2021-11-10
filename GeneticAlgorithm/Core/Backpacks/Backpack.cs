using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Core.Items;

namespace GeneticAlgorithm.Core.Backpacks
{
    internal class Backpack : IBackpack
    {
        public int MaxWeight { get; }
        public int CurrentWeight => Items.Sum(item => item.Weight);
        public List<IItem> Items { get; }

        public Backpack(int maxWeight)
        {
            MaxWeight = maxWeight;
            Items = new();
        }
    }
}
