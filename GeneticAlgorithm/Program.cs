using GeneticAlgorithm.Core;
using GeneticAlgorithm.Hanlders;
using Newtonsoft.Json;
using System.IO;

namespace GeneticAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("config.json");
            Config config = JsonConvert.DeserializeObject<Config>(data);
            new InputHandler(config).Menu();
        }
    }
}
