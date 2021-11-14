﻿using GeneticAlgorithm.Core.Items;
using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.Core.Individuals
{
    internal class Individual : IIndividual
    {
        public int EvolutionaryFitness { get; set; }
        public int Weight { get; set; }
        public bool IsAlive { get; set; }
        public int[] Chromosomes { get; }

        public Individual(int[] chromosomes)
        {
            Chromosomes = chromosomes;
            IsAlive = true;
        }

        public bool TryMutate(Random random, double mutationChance, out IIndividual individual)
        {
            double chance = random.NextDouble();
            if (mutationChance < chance)
            {
                individual = this;
                return false;
            }

            individual = Mutate();

            return true;
        }

        public IIndividual Mutate()
        {
            Random random = new();
            int chromosome = random.Next(Chromosomes.Length);
            int[] mutatedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, mutatedChromosomes, Chromosomes.Length);
            if (mutatedChromosomes[chromosome] > 1)
            {
                mutatedChromosomes[chromosome] -= 1;
            }

            return new Individual(mutatedChromosomes);
        }

        public IIndividual[] Crossingover(IIndividual parent)
        {
            Random random = new();
            IIndividual[] childs = new IIndividual[Chromosomes.Length];
            childs[0] = new Individual(new int[Chromosomes.Length]);
            childs[1] = new Individual(new int[Chromosomes.Length]);

            int index = random.Next(Chromosomes.Length);
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                if (i < index)
                {
                    childs[0].Chromosomes[i] = Chromosomes[i];
                    childs[1].Chromosomes[i] = parent.Chromosomes[i];
                }
                else
                {
                    childs[0].Chromosomes[i] = parent.Chromosomes[i];
                    childs[1].Chromosomes[i] = Chromosomes[i];
                }
            }

            return childs;
        }

        public static IIndividual[] RemoveDeadChildren(int maxWeight, IItem[] items, IIndividual[] childs)
        {
            List<IIndividual> alive = new();
            foreach (IIndividual child in childs)
            {
                if (child.CheckWeight(maxWeight, items))
                {
                    alive.Add(child);
                }
            }

            return alive.ToArray();
        }

        public IIndividual LocalUpgrade()
        {
            Random random = new();
            int chromosome = random.Next(Chromosomes.Length);
            int[] mutatedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, mutatedChromosomes, Chromosomes.Length);
            if (mutatedChromosomes[chromosome] > 1)
            {
                mutatedChromosomes[chromosome] -= 1;
            }

            return new Individual(mutatedChromosomes);
        }

        public bool CheckWeight(int maxWeight, IItem[] items)
        {
            double weight = 0;
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                weight += items[i].Weight * Chromosomes[i];
            }

            if (weight <= maxWeight)
            {
                return true;
            }

            IsAlive = false;
            return false;
        }
    }
}
