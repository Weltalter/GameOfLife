using BenchmarkDotNet.Running;

namespace GameOfLife.Benchmarks {
    public class Program {
        public static void Main() {
            var summary = BenchmarkRunner.Run<ClassicGameBenchmark>();
        }
    }
}
