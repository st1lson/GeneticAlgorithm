using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Core.Items
{
    internal class Item : IItem
    {
        public string Name { get; }
        public int Weight { get; }
        private static string[] _items;

        public Item(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public static List<IItem> RandomItems(Random random)
        {
            _items ??= InitItems();
            List<IItem> items = new();
            for (int i = 0; i < 10; i++)
            {
                int item = random.Next(5);
                int weight = random.Next(10);
                items.Add(new Item(_items[item], weight));
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
