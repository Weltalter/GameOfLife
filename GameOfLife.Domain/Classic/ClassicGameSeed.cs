using GameOfLife.Domain;

namespace GameOfLife.Domain {
    public static class ClassicGameSeed {
        public static class StillLifes {
            public static ClassicInfiniteToroidalGameGrid Block
                => ClassicInfiniteToroidalGameGrid.Create(new[,] {
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Alive, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Alive, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                });
        }

        public static class Oscillators {
            public static ClassicInfiniteToroidalGameGrid Blinker
                => ClassicInfiniteToroidalGameGrid.Create(new[,] {
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                });
        }

        public static class Spaceships {
            public static ClassicInfiniteToroidalGameGrid SimpleGlider
                => ClassicInfiniteToroidalGameGrid.Create(new[,] {
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Alive, ClassicCell.Alive, ClassicCell.Dead, ClassicCell.Dead },
                    { ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead, ClassicCell.Dead },
                });
            public static ClassicInfiniteToroidalGameGrid Glider25x25 {
                get {
                    var seed = new ClassicCell[25, 25];

                    seed[11, 12] = ClassicCell.Alive;
                    seed[12, 13] = ClassicCell.Alive;
                    seed[13, 11] = ClassicCell.Alive;
                    seed[13, 12] = ClassicCell.Alive;
                    seed[13, 13] = ClassicCell.Alive;

                    return ClassicInfiniteToroidalGameGrid.Create(seed);
                }
            }
            public static ClassicInfiniteToroidalGameGrid Lightweight {
                get {
                    var seed = new ClassicCell[25, 25];

                    seed[10, 11] = ClassicCell.Alive;
                    seed[10, 12] = ClassicCell.Alive;
                    seed[10, 13] = ClassicCell.Alive;
                    seed[10, 14] = ClassicCell.Alive;
                    seed[11, 10] = ClassicCell.Alive;
                    seed[11, 14] = ClassicCell.Alive;
                    seed[12, 14] = ClassicCell.Alive;
                    seed[13, 10] = ClassicCell.Alive;
                    seed[13, 13] = ClassicCell.Alive;

                    return ClassicInfiniteToroidalGameGrid.Create(seed);
                }
            }
        }
    }
}
