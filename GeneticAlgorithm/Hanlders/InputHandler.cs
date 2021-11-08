using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Items;
using System;
using System.Text;
using System.Collections.Generic;
using GeneticAlgorithm.Algorithms;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class InputHandler
    {
        private List<IItem> _items;
        private IAlgorithm _algorithm;
        private readonly FileHandler _fileHandler;
        private readonly Config _config;
        private readonly Random _random;
        private readonly string _menu;

        public InputHandler(Config config)
        {
            _config = config;
            _fileHandler = new(_config.Path);
            _random = new();
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

            Console.WriteLine("Press 'Enter' key to continue");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (!ConsoleKey.Enter.Equals(consoleKey))
            {
                return;
            }

            Console.Clear();
            Menu();
        }

        private void Action(int value)
        {
            switch (value)
            {
                case 1:
                    _items ??= _fileHandler.DeserializeItems(_config.Separator);
                    _algorithm ??= new GenAlgorithm(_config, _items);
                    if (_algorithm.TrySolve(out int result))
                    {
                        Console.WriteLine(result);
                    }

                    return;
                case 2:
                    _items = Item.RandomItems(_random);
                    _fileHandler.SerializeItems(_items);
                    Console.WriteLine("Items was successfully randomized");
                    return;
                case 3:
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
            stringBuilder.Append("Enter '2' to random items\n");
            stringBuilder.Append("Enter '3' to exit\n");

            return stringBuilder.ToString();
        }
    }
}
