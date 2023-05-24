namespace GameOfLife.Domain {
    public interface IGameGridStringifier<TGameGrid, TCell>
        where TGameGrid : IGameGrid<TCell> {
        string Stringify(TGameGrid gameGrid);
    }
}
