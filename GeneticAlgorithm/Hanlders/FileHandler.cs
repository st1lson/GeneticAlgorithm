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

        public List<IItem> DeserializeItems(string separator)
        {
            List<IItem> items = new();
            using StreamReader streamReader = new(_path, Encoding.Default);
            string line = streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (!Int32.TryParse(parts[1], out int weight))
                {
                    throw new Exception("Wrong file format");
                }

                items.Add(new Item(parts[0], weight));
            }

            return items;
        }

        public void SerializeItems(List<IItem> items)
        {
            using StreamWriter streamWriter = new(_path, false, Encoding.Default);
            streamWriter.WriteLine(items.Count);
            foreach(IItem item in items)
            {
                streamWriter.WriteLine(item);
            }
        }
    }
}
