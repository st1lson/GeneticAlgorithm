﻿using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Backpacks;
using GeneticAlgorithm.Core.Individuals;
using GeneticAlgorithm.Core.Items;
using GeneticAlgorithm.Core.Populations;
using System;
using System.Linq;

namespace GeneticAlgorithm.Algorithms
{
    internal class GenAlgorithm : IAlgorithm
    {
        private readonly Config _config;
        private readonly Random _random;
        private readonly IItem[] _items;
        private readonly IPopulation _population;
        private readonly IBackpack _backpack;

        public GenAlgorithm(Config config, Random random, IItem[] items)
        {
            _config = config;
            _random = random;
            _items = items;
            _population = new Population(_config.PopulationCount);
            _backpack = new Backpack(_config.MaxWeight, items);
        }

        public bool TrySolve(out Result result)
        {
            result = Solve();
            /*try
            {
                result = Solve();
            }
            catch (Exception)
            {
                result = default;
                return false;
            }*/

            return true;
        }

        public Result Solve()
        {
            Result result = new();
            InitializePopulation();
            int iterator = 0;
            while (iterator < _config.IterationsCount)
            {
                foreach (IIndividual individual in _population.Individuals)
                {
                    _backpack.Solve(individual);
                }

                UpdatePopulation();
                iterator++;
            }

            result.End();
            return result;
        }

        private void InitializePopulation()
        {
            for (int i = 0; i < _config.PopulationCount; i++)
            {
                _population.Individuals[i] = new Individual(InitialSetup(i));
                _population.Individuals[i].EvolutionaryFitness = 
                    CalculateEvolutionaryFitness(_population.Individuals[i]);
                _population.Individuals[i].Weight = 
                    CalculateWeight(_population.Individuals[i]);
            }
        }

        private void UpdatePopulation()
        {
            IIndividual bestParent = _population.Individuals.OrderByDescending(x => x.EvolutionaryFitness).First();
            IIndividual randomParent = _population.Individuals[_random.Next(_config.PopulationCount)];
            IIndividual[] childs = bestParent.Crossingover(randomParent);
            childs = Individual.RemoveDeadChildren(_config.MaxWeight, _items, childs);

            foreach (IIndividual child in childs)
            {
                child.TryMutate(_random, _config.EvolutionChance, out IIndividual mutatedChild);
                if (!mutatedChild.CheckWeight(_config.MaxWeight, _items))
                {
                    mutatedChild = child;
                }

                IIndividual updatedChild = mutatedChild.LocalUpgrade();
                if (!updatedChild.CheckWeight(_config.MaxWeight, _items))
                {
                    updatedChild = mutatedChild;
                }

                IIndividual worstIndividual = _population.Individuals.OrderBy(x => x.EvolutionaryFitness).First();
                if (updatedChild.CheckWeight(_config.MaxWeight, _items) &&
                    !_population.Individuals.Contains(updatedChild) &&
                    updatedChild.EvolutionaryFitness > worstIndividual.EvolutionaryFitness)
                {
                    _population.Replace(updatedChild);
                }
            }
        }

        private int CalculateEvolutionaryFitness(IIndividual individual)
        {
            int cost = 0;
            for (int i = 0; i < individual.Chromosomes.Length; i++)
            {
                cost += _items[i].Cost * individual.Chromosomes[i];
            }

            return cost;
        }

        private int CalculateWeight(IIndividual individual)
        {
            int weight = 0;
            for (int i = 0; i < individual.Chromosomes.Length; i++)
            {
                weight += _items[i].Weight * individual.Chromosomes[i];
            }

            return weight;
        }

        private int[] InitialSetup(int index)
        {
            int weight = 0;
            int[] chromosomes = new int[_items.Length];
            for (int i = 0; i < _items.Length; i++)
            {
                if (index != i)
                {
                    continue;
                }

                chromosomes[i] = _items[i].Cost;
                weight += _items[i].Weight;
            }

            return chromosomes;
        }
    }
}
