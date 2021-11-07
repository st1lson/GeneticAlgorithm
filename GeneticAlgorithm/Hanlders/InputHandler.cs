using GeneticAlgorithm.Core;
using System;
using System.Text;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class InputHandler
    {
        private readonly FileHandler _fileHandler;
        private readonly Config _config;
        private readonly string _menu;

        public InputHandler(Config config)
        {
            _config = config;
            _fileHandler = new(_config.Path);
            _menu = CreateMenu();
        }

        public void Menu()
        {
            Console.WriteLine(_menu);

            Menu();
        }

        private string CreateMenu()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("Enter '1' to solve the backpack task\n");
            stringBuilder.Append("Enter '2' to exit\n");

            return stringBuilder.ToString();
        }
    }
}
