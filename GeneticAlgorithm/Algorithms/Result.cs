using GeneticAlgorithm.Core.Individuals;
using System;
using System.Text;

namespace GeneticAlgorithm.Algorithms
{
    internal sealed class Result
    {
        public int Iteration { private get; set; }
        public IIndividual BestIndividual { get; set; }
        public TimeSpan Time { get; private set; }
        private readonly DateTime _startTime;
        private bool _finished;

        public Result()
        {
            _startTime = DateTime.Now;
        }

        public void End()
        {
            Time = DateTime.Now - _startTime;
            _finished = true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"Iterations: {Iteration}\n");
            stringBuilder.Append($"Best individual: {BestIndividual}\n");
            stringBuilder.Append(_finished ? $"Ended in {Time.TotalSeconds}\n" : $"Current time is {(DateTime.Now - _startTime).TotalSeconds}\n");

            return stringBuilder.ToString();
        }
    }
}
