using GeneticAlgorithm.Core.Items;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (mutationChance > chance)
            {
                individual = this;
                return false;
            }

            individual = SecondMutation();

            return true;
        }

        public IIndividual FirstMutation()
        {
            Random random = new();
            int[] mutatedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, mutatedChromosomes, Chromosomes.Length);
            int firstIndex = random.Next(Chromosomes.Length / 2);
            int secondIndex = random.Next(firstIndex, Chromosomes.Length);

            (Chromosomes[firstIndex], Chromosomes[secondIndex]) = (Chromosomes[secondIndex], Chromosomes[firstIndex]);

            return new Individual(mutatedChromosomes);
        }

        public IIndividual SecondMutation()
        {
            Random random = new();
            int[] mutatedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, mutatedChromosomes, Chromosomes.Length);
            int index = random.Next(Chromosomes.Length);

            if (mutatedChromosomes[index] > 1)
            {
                mutatedChromosomes[index] -= 1;
            }
            else
            {
                mutatedChromosomes[index] = 0;
            }

            return new Individual(mutatedChromosomes);
        }

        public IIndividual[] SinglePointCrossingover(IIndividual parent) // Single-point crossover
        {
            Random random = new();
            IIndividual[] childs = new IIndividual[2];
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

        public IIndividual[] TwoPointCrossingover(IIndividual parent)
        {
            Random random = new();
            IIndividual[] childs = new IIndividual[2];
            childs[0] = new Individual(new int[Chromosomes.Length]);
            childs[1] = new Individual(new int[Chromosomes.Length]);
            int firstPoint = random.Next(Chromosomes.Length);
            int secondPoint = random.Next(firstPoint, Chromosomes.Length);
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                if (i < firstPoint || i > secondPoint)
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

        public IIndividual[] UniformCrossingover(IIndividual parent, double crossingoverChance)
        {
            Random random = new();
            IIndividual[] childs = new IIndividual[2];
            childs[0] = new Individual(new int[Chromosomes.Length]);
            childs[1] = new Individual(new int[Chromosomes.Length]);
            for (int i = 0; i < Chromosomes.Length; i++)
            {
                double currentChance = random.NextDouble();
                if (currentChance > crossingoverChance)
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

        public IIndividual FirstLocalUpgrade()
        {
            Random random = new();
            int[] upgradedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, upgradedChromosomes, Chromosomes.Length);
            int indexer = random.Next(Chromosomes.Length);
            while (Chromosomes[indexer] > 0)
            {
                indexer = random.Next(Chromosomes.Length);
            }

            upgradedChromosomes[indexer] = 1;

            return new Individual(upgradedChromosomes);
        }

        public IIndividual SecondLocalUpgrade()
        {
            Random random = new();
            int[] upgradedChromosomes = new int[Chromosomes.Length];
            Array.Copy(Chromosomes, upgradedChromosomes, Chromosomes.Length);
            int index = random.Next(Chromosomes.Length);

            upgradedChromosomes[index] += 1;

            return new Individual(upgradedChromosomes);
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

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"Fitness: {EvolutionaryFitness};\n");
            stringBuilder.Append($"Weight: {Weight};\n");

            return stringBuilder.ToString();
        }
    }
}
