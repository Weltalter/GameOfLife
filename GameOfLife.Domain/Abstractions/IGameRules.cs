namespace GameOfLife.Domain {
    public interface IGameRules<TGameGrid, TCell>
        where TGameGrid : IGameGrid<TCell> {
        TGameGrid Apply(TGameGrid oldGrid);
    }
}
