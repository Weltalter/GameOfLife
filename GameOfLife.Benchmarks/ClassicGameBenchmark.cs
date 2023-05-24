using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using GameOfLife.Domain;

namespace GameOfLife.Benchmarks {
    [MemoryDiagnoser]
    public class ClassicGameBenchmark {
        private readonly Consumer _consumer = new ();

        private ClassicGame _game;

        [IterationSetup]
        public void IterationSetup() {
            var seed = ClassicGameSeed.Spaceships.Glider25x25;

            var rules = ClassicGameRules.Instance;

            _game = ClassicGame.Create(rules, seed);
        }

        [Params(1, 10, 100, 200, 500, 1000, 2000, 5000, 10000)]
        public int Iterations;

        [Benchmark]
        public void Iterate() 
            => _game.Take(Iterations).Consume(_consumer);
    }
}
