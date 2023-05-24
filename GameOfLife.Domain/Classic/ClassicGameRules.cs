using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Domain {
    public sealed class ClassicGameRules : IGameRules<ClassicInfiniteToroidalGameGrid, ClassicCell> {
        public static ClassicGameRules Instance { get; } = new ();

        public ClassicInfiniteToroidalGameGrid Apply(ClassicInfiniteToroidalGameGrid oldGrid) {
            var newGrid = new ClassicCell[oldGrid.Rows, oldGrid.Columns];

            for (int row = 0; row < oldGrid.Rows; row++) {
                for (int column = 0; column < oldGrid.Columns; column++) {
                    newGrid[row, column] = CalculateCellStatus(oldGrid, row, column);
                }
            }

            return ClassicInfiniteToroidalGameGrid.Create(newGrid);
        }

        private static ClassicCell CalculateCellStatus(ClassicInfiniteToroidalGameGrid current, int row, int column) {
            var neighbours = GetMooreNeighbours(current, row, column);
            var aliveNeighbours = neighbours.Count(n => n == ClassicCell.Alive);
            var currentCell = current.Grid[row, column];
            var newCell = currentCell switch {
                ClassicCell.Alive when aliveNeighbours == 2 || aliveNeighbours == 3 => ClassicCell.Alive,
                ClassicCell.Dead when aliveNeighbours == 3 => ClassicCell.Alive,
                _ => ClassicCell.Dead
            };

            return newCell;
        }
        private static IEnumerable<ClassicCell> GetMooreNeighbours(ClassicInfiniteToroidalGameGrid current, int row, int column) {
            // 0 1 2
            // 3 _ 4 
            // 5 6 7
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (i == 0 && j == 0) {
                        continue;
                    }

                    var normalizedRow = Normalize(row + i, current.Rows);
                    var normalizedColumn = Normalize(column + j, current.Columns);

                    yield return current.Grid[normalizedRow, normalizedColumn];
                }
            }
        }

        private static int Normalize(int current, int total)
            => (current + total) % total;
    }
}
