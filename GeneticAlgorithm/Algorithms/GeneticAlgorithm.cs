using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Backpacks;
using GeneticAlgorithm.Core.Items;
using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.Algorithms
{
    internal class GeneticAlgorithm : IAlgorithm
    {
        private readonly Config _config;
        private readonly List<IItem> _items;
        private readonly IBackpack _backpack;

        public GeneticAlgorithm(Config config, List<IItem> items)
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
