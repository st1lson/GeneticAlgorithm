namespace GeneticAlgorithm.Core.Items
{
    internal interface IItem
    {
        public string Name { get; }
        public int Cost { get; }
        public int Weight { get; }
    }
}
