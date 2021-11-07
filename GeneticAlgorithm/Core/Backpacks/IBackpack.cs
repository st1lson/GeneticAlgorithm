using GeneticAlgorithm.Core.Items;
using System.Collections.Generic;

namespace GeneticAlgorithm.Core
{
    internal interface IBackpack
    {
        public int MaxWeight { get; }
        public int CurrentWeight { get; }
        public List<IItem> Items { get; }

        public bool TrySolve(out int result);
        public int Solve();
    }
}
