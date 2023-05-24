using System;
using System.Globalization;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GameOfLife.ViewModels;
using ReactiveUI;

namespace GameOfLife.WpfUi {
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class ClassicGameGridView : ReactiveUserControl<ClassicGameGridViewModel> {
        public ClassicGameGridView() {
            InitializeComponent();

            this.WhenActivated(disposableRegistration => {
                this.OneWayBind(
                    ViewModel,
                    vm => vm.GameGrid,
                    v => v.gameContentControl.Content,
                    ConvertVmToView)
                .DisposeWith(disposableRegistration);
            });
        }

        private object ConvertVmToView(ClassicGameGridCellViewModel[,] vm) {
            var grid = new Grid {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var rows = vm.GetLength(0);
            var columns = vm.GetLength(1);
            var rowHeight = gameContentControl.ActualHeight / rows;
            var columnWidth = gameContentControl.ActualWidth / columns;

            var rectangleSize = Math.Min(rowHeight, columnWidth);

            for (int row = 0; row < rows; row++) {
                grid.RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column < columns; column++) {
                    if (row == 0) {
                        grid.ColumnDefinitions.Add(new ColumnDefinition());
                    }

                    var rectangle = CreateRectangle(vm, row, column, rectangleSize, rectangleSize);

                    Grid.SetRow(rectangle, row);
                    Grid.SetColumn(rectangle, column);

                    grid.Children.Add(rectangle);
                }
            }

            return grid;
        }

        private Rectangle CreateRectangle(ClassicGameGridCellViewModel[,] grid, int row, int column, double height, double width) {
            var rectangle = new Rectangle {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = height,
                Width = width,
                DataContext = grid[row, column],
                Stroke = Brushes.White,
                StrokeThickness = 1,
            };

            var leftClickBinding = new InputBinding(
                ViewModel.SwitchCellStatus,
                new MouseGesture(MouseAction.LeftClick)) {
                    CommandParameter = (row, column)
                };
            rectangle.InputBindings.Add(leftClickBinding);

            var aliveCellBinding = new Binding {
                Path = new PropertyPath("IsAlive"),
                Mode = BindingMode.TwoWay,
                Converter = CellToColorConverter.Create(
                        aliveColor: new SolidColorBrush(Color.FromArgb(0xFF, 0x32, 0xCD, 0x32)),
                        deadColor: Brushes.LightGray)
            };
            rectangle.SetBinding(Rectangle.FillProperty, aliveCellBinding);

            return rectangle;
        }
    }

    public class CellToColorConverter : IValueConverter {
        public SolidColorBrush AliveColor { get; }
        public SolidColorBrush DeadColor { get; }

        private CellToColorConverter(SolidColorBrush aliveColor, SolidColorBrush deadColor) {
            AliveColor = aliveColor;
            DeadColor = deadColor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value is bool isAlive
                && isAlive 
                ? AliveColor 
                : DeadColor;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => value is SolidColorBrush brush && brush == AliveColor;

        public static CellToColorConverter Create(
            SolidColorBrush aliveColor,
            SolidColorBrush deadColor)
            => new(aliveColor, deadColor);
    }
}
