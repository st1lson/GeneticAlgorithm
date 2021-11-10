namespace GeneticAlgorithm.Core
{
    internal sealed class Config
    {
        public string Path { get; set; }
        public string[] Separators { get; set; }
        public string[] PossibleItems { get; set; }
        public int MaxWeight { get; set; }
        public int ItemsCount { get; set; }
        public int MinItemCost { get; set; }
        public int MaxItemCost { get; set; }
        public int MinItemWeight { get; set; }
        public int MaxItemWeight { get; set; }
        public double EvolutionChance { get; set; }
    }
}
