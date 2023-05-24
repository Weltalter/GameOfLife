using GameOfLife.Domain;

namespace GameOfLife.ViewModels.Converters {
    public static class ClassicInfiniteToroidalGameGridConverter {
        public static ClassicGameGridCellViewModel[,] FillVm(this ClassicInfiniteToroidalGameGrid gameGrid) {
            var result = new ClassicGameGridCellViewModel[gameGrid.Rows, gameGrid.Columns];

            for (int i = 0; i < gameGrid.Rows; i++) {
                for (int j = 0; j < gameGrid.Columns; j++) {
                    result[i, j] = new ClassicGameGridCellViewModel {
                        IsAlive = gameGrid.Grid[i, j] == ClassicCell.Alive
                    };

                }
            }

            return result;
        }

        public static ClassicInfiniteToroidalGameGrid ExtractGameGrid(this ClassicGameGridViewModel vm) {
            var grid = new ClassicCell[vm.Rows, vm.Columns];

            for (int i = 0; i < vm.Rows; i++) {
                for (int j = 0; j < vm.Columns; j++) {
                    grid[i, j] = vm.GameGrid[i, j].IsAlive
                        ? ClassicCell.Alive
                        : ClassicCell.Dead;
                }
            }

            return ClassicInfiniteToroidalGameGrid.Create(grid);
        }
    }
}
