using System.Windows;

using WpfDemoApp.ViewModels;

namespace WpfDemoApp
{
    public partial class MainWindow : Window
    {
        private MainPageViewModel _viewModel;

        public MainWindow(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            _viewModel.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = GamesList.ItemsSource;
        }
    }
}
