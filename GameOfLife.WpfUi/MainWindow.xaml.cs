using System.Reactive.Disposables;
using GameOfLife.ViewModels;
using ReactiveUI;
using Splat;

namespace GameOfLife.WpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();

            ViewModel = Locator.Current.GetService<MainViewModel>();

            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(
                    ViewModel,
                    vm => vm.GameGridVm,
                    v => v.gameGridView.ViewModel)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(
                    ViewModel,
                    vm => vm.GameGridVm,
                    v => v.InfoGameLabel.Content,
                    vm => $"{vm.Rows} x {vm.Columns}")
                    .DisposeWith(disposableRegistration);

                this.BindCommand(
                    ViewModel,
                    viewModel => viewModel.Tick,
                    view => view.tickButton)
                    .DisposeWith(disposableRegistration);

                this.BindCommand(
                    ViewModel,
                    viewModel => viewModel.Reset,
                    view => view.resetButton)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
