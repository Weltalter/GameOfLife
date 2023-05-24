using System.Reactive;
using GameOfLife.Domain;
using GameOfLife.ViewModels.Converters;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace GameOfLife.ViewModels {
    public class MainViewModel : ReactiveObject {
        private readonly ClassicGameRules _classicGameRules;

        public MainViewModel(ClassicGameRules classicGameRules) {
            _classicGameRules = classicGameRules;
            GameGridVm = new ClassicGameGridViewModel(ClassicInfiniteToroidalGameGrid.Default.FillVm());
            Tick = ReactiveCommand.Create(TickInternal);
            Reset = ReactiveCommand.Create(ResetInternal);
        }

        [Reactive]
        public ClassicGameGridViewModel GameGridVm { get; set; }

        public void TickInternal() {
            var newGameGrid = _classicGameRules.Apply(GameGridVm.ExtractGameGrid());
            GameGridVm = new ClassicGameGridViewModel(newGameGrid.FillVm());
        }
        public ReactiveCommand<Unit, Unit> Tick { get; }

        public void ResetInternal() {
            GameGridVm = new ClassicGameGridViewModel(ClassicInfiniteToroidalGameGrid.Default.FillVm());
        }
        public ReactiveCommand<Unit, Unit> Reset { get; }
    }
}
