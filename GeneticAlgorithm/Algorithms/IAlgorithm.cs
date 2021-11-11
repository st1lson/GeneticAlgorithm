﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Algorithms
{
    internal interface IAlgorithm
    {
        public bool TrySolve(out Result result);
        public Result Solve();
    }
}
