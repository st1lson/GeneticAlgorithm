using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Core.Individuals;
using GeneticAlgorithm.Core.Items;

namespace GeneticAlgorithm.Core.Backpacks
{
    internal class Backpack : IBackpack
    {
        public int MaxWeight { get; }
        public int CurrentWeight => Items.Sum(item => item.Weight);
        public List<IItem> Items { get; }
        private readonly IItem[] _items;

        public Backpack(int maxWeight, IItem[] items)
        {
            MaxWeight = maxWeight;
            Items = new();
            _items = items;
        }

        public void Solve(IIndividual individual)
        {
            for (int i = 0; i < individual.Chromosomes.Length; i++)
            {
                for (int j = 0; j < individual.Chromosomes[i]; j++)
                {
                    Items.Add(_items[i]);
                }
            }
        }
    }
}
