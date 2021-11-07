using GeneticAlgorithm.Core;
using GeneticAlgorithm.Hanlders;

namespace GeneticAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Config config = new()
            {
                Path = "default.txt"
            };

            new InputHandler(config).Menu();
        }
    }
}
