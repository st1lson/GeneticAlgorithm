using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Backpacks;
using GeneticAlgorithm.Core.Items;
using System;

namespace GeneticAlgorithm.Algorithms
{
    internal class GenAlgorithm : IAlgorithm
    {
        private readonly Config _config;
        private readonly IItem[] _items;
        private readonly IBackpack _backpack;

        public GenAlgorithm(Config config, IItem[] items)
        {
            _config = config;
            _items = items;
            _backpack = new Backpack(_config.MaxWeight);
        }

        public bool TrySolve(out int result)
        {
            try
            {
                result = Solve();
            }
            catch (Exception)
            {
                result = default;
                return false;
            }

            return true;
        }

        public int Solve()
        {
            return default;
        }

        private void ChangePopulation()
        {

        }

        private void InitializePopulation()
        {

        }
    }
}
