using System.IO;
using System.Text;

namespace GeneticAlgorithm.Hanlders
{
    internal sealed class FileHandler
    {
        private readonly string _path;

        public FileHandler(string path) => _path = path;

        public string Read()
        {
            using StreamReader streamReader = new(_path, Encoding.Default);
            return streamReader.ReadToEnd();
        }
    }
}
