using System.Collections.Generic;

namespace GameOfLife.Domain {
    public interface IGame<TGameGrid, TGameRules, TCell> : IEnumerable<TGameGrid>
        where TGameGrid : IGameGrid<TCell>
        where TGameRules : IGameRules<TGameGrid, TCell> {
        TGameGrid Initial { get; }
    }
}
