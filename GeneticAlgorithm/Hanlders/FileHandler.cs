using GeneticAlgorithm.Core.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class FileHandler
    {
        private readonly string _path;

        public FileHandler(string path) => _path = path;

        public List<IItem> DeserializeItems()
        {
            List<IItem> items = new();
            using StreamReader streamReader = new(_path, Encoding.Default);
            while(!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] parts = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (!Int32.TryParse(parts[1], out int weight))
                {
                    throw new Exception("Wrong file format");
                }

                items.Add(new Item(parts[0], weight));
            }

            return items;
        }
    }
}
