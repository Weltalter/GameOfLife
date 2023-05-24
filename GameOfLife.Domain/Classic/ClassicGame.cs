using System.Collections;
using System.Collections.Generic;
using Dawn;

namespace GameOfLife.Domain {
    public sealed class ClassicGame : IGame<ClassicInfiniteToroidalGameGrid, ClassicGameRules, ClassicCell> {
        private readonly ClassicGameRules _rules;

        public ClassicInfiniteToroidalGameGrid Initial { get; }

        private ClassicGame(ClassicGameRules rules, ClassicInfiniteToroidalGameGrid grid) {
            _rules = Guard.Argument(rules, nameof(rules)).NotNull();
            Initial = Guard.Argument(grid, nameof(grid)).NotNull();
        }

        public IEnumerator<ClassicInfiniteToroidalGameGrid> GetEnumerator() {
            var current = Initial;

            while (true) {
                yield return current;

                current = _rules.Apply(current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public static ClassicGame Create(ClassicGameRules rules, ClassicInfiniteToroidalGameGrid grid)
            => new (rules, grid);

        public static ClassicGame Default { get; } = new (ClassicGameRules.Instance, ClassicInfiniteToroidalGameGrid.Default);
    }
}
