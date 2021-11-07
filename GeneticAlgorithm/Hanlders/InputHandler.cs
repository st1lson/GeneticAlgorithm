using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Items;
using System;
using System.Text;
using System.Collections.Generic;
using GeneticAlgorithm.Core.Backpacks;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class InputHandler
    {
        private List<IItem> _items;
        private IBackpack _backpack;
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
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out int value))
            {
                Console.WriteLine("Input should be an integer");
            }

            Action(value);

            Menu();
        }

        private void Action(int value)
        {
            switch (value)
            {
                case 1:
                    _items ??= _fileHandler.DeserializeItems();
                    _backpack ??= new Backpack(_config.MaxWeight, _items);
                    if (_backpack.TrySolve(out int result))
                    {
                        Console.WriteLine(result);
                    }

                    return;
                case 2:
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
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
