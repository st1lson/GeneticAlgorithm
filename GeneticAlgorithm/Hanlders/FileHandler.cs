using GeneticAlgorithm.Core.Items;
using System;
using System.IO;
using System.Text;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class FileHandler
    {
        private readonly string _path;

        public FileHandler(string path) => _path = path;

        public IItem[] DeserializeItems(string[] separators)
        {
            using StreamReader streamReader = new(_path, Encoding.Default);
            string line = streamReader.ReadLine();
            if (!Int32.TryParse(line, out int itemsCount))
            {
                return default;
            }

            IItem[] items = new IItem[itemsCount];
            int i = 0;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (!Int32.TryParse(parts[1], out int weight))
                {
                    throw new Exception("Wrong file format");
                }

                if (!Int32.TryParse(parts[2], out int cost))
                {
                    throw new Exception("Wrong file format");
                }

                items[i++] = new Item(parts[0], cost, weight);
            }

            return items;
        }

        public void SerializeItems(IItem[] items)
        {
            using StreamWriter streamWriter = new(_path, false, Encoding.Default);
            streamWriter.WriteLine(items.Length);
            foreach(IItem item in items)
            {
                streamWriter.WriteLine(item);
            }
        }
    }
}
