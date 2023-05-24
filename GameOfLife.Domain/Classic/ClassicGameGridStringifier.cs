using System.Text;
using Dawn;

namespace GameOfLife.Domain {
    public sealed class ClassicGameGridStringifier : IGameGridStringifier<ClassicInfiniteToroidalGameGrid, ClassicCell> {
        public char AliveCell { get; }
        public char DeadCell { get; }

        private ClassicGameGridStringifier(char aliveCell, char deadCell) {
            AliveCell = Guard.Argument(aliveCell, nameof(aliveCell)).NotDefault();
            DeadCell = Guard.Argument(deadCell, nameof(deadCell)).NotDefault();
        }

        public string Stringify(ClassicInfiniteToroidalGameGrid gameGrid) {
            var sb = new StringBuilder();

            sb.AppendLine($"Grid ({gameGrid.Rows}x{gameGrid.Columns})");

            for (int row = 0; row < gameGrid.Rows; row++) {
                for (int column = 0; column < gameGrid.Columns; column++) {
                    var cell = gameGrid.Grid[row, column];

                    var printedCharacter = cell switch {
                        ClassicCell.Alive => AliveCell,
                        _ => DeadCell
                    };

                    sb.Append(printedCharacter);

                    if (column == gameGrid.Columns - 1) {
                        sb.AppendLine();
                    }
                }
            }

            return sb.ToString();
        }

        public static ClassicGameGridStringifier Create(char aliveCell, char deadCell)
            => new (aliveCell, deadCell);
    }
}
