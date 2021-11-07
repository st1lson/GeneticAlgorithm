using System;
using System.Collections.Generic;
using GeneticAlgorithm.Core.Items;

namespace GeneticAlgorithm.Core.Backpacks
{
    internal class Backpack : IBackpack
    {
        public int MaxWeight { get; }
        public int CurrentWeight { get; }
        public List<IItem> Items { get; }

        public Backpack(int maxWeight, List<IItem> items)
        {
            MaxWeight = maxWeight;
            Items = items;
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
    }
}
