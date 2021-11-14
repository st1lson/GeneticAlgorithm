namespace GeneticAlgorithm.Algorithms
{
    internal interface IAlgorithm
    {
        public bool TrySolve(out Result result);
        public Result Solve();
    }
}
