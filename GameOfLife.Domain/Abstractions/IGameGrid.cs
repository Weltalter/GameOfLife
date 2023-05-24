using System.Collections.Generic;

namespace GameOfLife.Domain {
    public interface IGameGrid<TCell> : IEnumerable<TCell> {
        public int Rows { get; }
        public int Columns { get; }
    }
}
