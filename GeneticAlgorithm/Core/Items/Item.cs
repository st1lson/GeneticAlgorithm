using System;

namespace GeneticAlgorithm.Core.Items
{
    internal class Item : IItem
    {
        public string Name { get; }
        public int Cost { get; }
        public int Weight { get; }
        private static string[] _items;

        public Item(string name, int cost, int weight)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        public static IItem[] RandomItems(Random random, int itemsCount, int minCost, int maxCost, int minWeight, int maxWeight)
        {
            _items ??= InitItems();
            IItem[] items = new IItem[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                int item = random.Next(_items.Length);
                int cost = random.Next(minCost, maxCost + 1);
                int weight = random.Next(minWeight, maxWeight + 1);
                items[i] = new Item(_items[item], cost, weight);
            }

            return items;
        }

        private static string[] InitItems() => new[] { "Pen", "Book", "Knife", "Phone", "Keys" };

        public override string ToString()
        {
            return $"{Name} with weight {Weight}";
        }
    }
}
