using System;

namespace GeneticAlgorithm.Core.Items
{
    internal class Item : IItem
    {
        public string Name { get; }
        public int Cost { get; }
        public int Weight { get; }
        public static string[] PossibleItems;

        public Item(string name, int cost, int weight)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        public static IItem[] RandomItems(Random random, int itemsCount, int minCost, int maxCost, int minWeight, int maxWeight)
        {
            IItem[] items = new IItem[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                int item = random.Next(PossibleItems.Length);
                int cost = random.Next(minCost, maxCost + 1);
                int weight = random.Next(minWeight, maxWeight + 1);
                items[i] = new Item(PossibleItems[item], cost, weight);
            }

            return items;
        }

        public override string ToString()
        {
            return $"{Name} with weight {Weight} and cost {Cost}";
        }
    }
}
