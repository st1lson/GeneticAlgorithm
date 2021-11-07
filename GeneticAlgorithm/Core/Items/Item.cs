using System.Text;

namespace GeneticAlgorithm.Core.Items
{
    internal class Item : IItem
    {
        public string Name { get; }
        public int Weight { get; }

        public Item(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} with weight {Weight}";
        }
    }
}
