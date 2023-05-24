using System.Diagnostics;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace GameOfLife.ViewModels {
    public class ClassicGameGridViewModel : ReactiveObject {
        public ClassicGameGridViewModel(ClassicGameGridCellViewModel[,] gameGrid) {
            GameGrid = gameGrid;
            Rows = gameGrid.GetLength(0);
            Columns = gameGrid.GetLength(1);
            SwitchCellStatus = ReactiveCommand.Create<(int height, int width), Unit>(SwitchCellStatusInternal);
        }

        public int Rows { get; }
        public int Columns { get; }

        public ClassicGameGridCellViewModel[,] GameGrid { get; }
        public ReactiveCommand<(int height, int width), Unit> SwitchCellStatus { get; }

        private Unit SwitchCellStatusInternal((int height, int width) t) {
            var previousStatus = GameGrid[t.height, t.width].IsAlive;

            GameGrid[t.height, t.width].IsAlive = !previousStatus;

            Debug.WriteLine($"Height: {t.height}. Width: {t.width}. Previous: {previousStatus}. Current: {GameGrid[t.height, t.width].IsAlive}");

            return Unit.Default;
        }
    }

    [DebuggerDisplay("{IsAlive, nq}")]
    public class ClassicGameGridCellViewModel : ReactiveObject {
        [Reactive]
        public bool IsAlive { get; set; }
    }
}
