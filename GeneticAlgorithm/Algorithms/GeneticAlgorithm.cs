using GeneticAlgorithm.Core;
using GeneticAlgorithm.Core.Backpacks;
using GeneticAlgorithm.Core.Individuals;
using GeneticAlgorithm.Core.Items;
using GeneticAlgorithm.Core.Populations;
using System;

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
            for (int i = 0; i < _config.IterationsCount; i++)
            {
                foreach (IIndividual individual in _population.Individuals)
                {
                    _backpack.Solve(individual);
                    individual.TryMutate(_random, _config.EvolutionChance, out IIndividual newIndividual);
                    if (newIndividual.CheckWeight(_config.MaxWeight, _items))
                    {
                        _population.Replace(newIndividual);
                    }
                }
            }

            result.End();

            return result;
        }

        private void InitializePopulation()
        {
            for (int i = 0; i < _config.PopulationCount; i++)
            {
                _population.Individuals[i] = new Individual(InitialSetup());
                _population.Individuals[i].EvolutionaryFitness = 
                    CalculateEvolutionaryFitness(_population.Individuals[i]);
                _population.Individuals[i].Weight = 
                    CalculateWeight(_population.Individuals[i]);
                _population.Individuals[i].CheckWeight(_config.MaxWeight, _items);
            }
        }

        private int CalculateEvolutionaryFitness(IIndividual individual)
        {
            int cost = 0;
            for (int i = 0; i < individual.Chromosomes.Length; i++)
            {
                if (individual.Chromosomes[i])
                {
                    cost += _items[i].Cost;
                }
            }

            return cost;
        }

        private int CalculateWeight(IIndividual individual)
        {
            int weight = 0;
            for (int i = 0; i < individual.Chromosomes.Length; i++)
            {
                if (individual.Chromosomes[i])
                {
                    weight += _items[i].Weight;
                }
            }

            return weight;
        }

        private bool[] InitialSetup()
        {
            int weight = 0;
            int pointer = 0;
            bool[] chromosomes = new bool[_items.Length];
            for (int i = 0; i < _items.Length; i++)
            {
                int value = _random.Next(2);
                chromosomes[i] = value != 0;    // _ = value == 0 ? chromosomes[i] = false : chromosomes[i] = true;
                weight += _items[i].Weight;
                if (weight > _config.MaxWeight)
                {
                    chromosomes[pointer] = !chromosomes[pointer];
                    return chromosomes;
                }

                pointer = i;
            }

            return chromosomes;
        }
    }
}
