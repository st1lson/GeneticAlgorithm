﻿using GeneticAlgorithm.Core.Items;
using System;

namespace GeneticAlgorithm.Core.Individuals
{
    internal interface IIndividual
    {
        public int EvolutionaryFitness { get; set; }
        public int Weight { get; set; }
        public bool IsAlive { get; set; }
        public bool[] Chromosomes { get; }

        public bool TryMutate(Random random, double mutationChance, out IIndividual individual);
        public IIndividual Mutate();

        public IIndividual Crossingover(IIndividual parent);

        public void LocalUpgrade();
        public bool CheckWeight(int maxWeight, IItem[] items);
    }
}
