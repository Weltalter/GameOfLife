using System.Collections;
using System.Collections.Generic;
using Dawn;

namespace GameOfLife.Domain {
    public sealed class ClassicInfiniteToroidalGameGrid : IGameGrid<ClassicCell> {
        public ClassicCell[,] Grid { get; }

        public int Rows => Grid.GetLength(0);
        public int Columns => Grid.GetLength(1);

        private ClassicInfiniteToroidalGameGrid(ClassicCell[,] grid) {
            Grid = Guard.Argument(grid, nameof(grid)).NotNull();
        }

        public IEnumerator<ClassicCell> GetEnumerator() {
            for (int row = 0; row < Rows; row++) {
                for (int column = 0; column < Columns; column++) {
                    yield return Grid[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public static ClassicInfiniteToroidalGameGrid Create(ClassicCell[,] grid)
            => new (grid);

        public static ClassicInfiniteToroidalGameGrid Default { get; } = new (new ClassicCell[25, 25]);
    }
}
