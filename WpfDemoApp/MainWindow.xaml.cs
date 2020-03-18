using System.Windows;

using WpfDemoApp.ViewModels;

namespace WpfDemoApp
{
    public partial class MainWindow : Window
    {
        private readonly MainPageViewModel _viewModel;

        public MainWindow(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            _viewModel.Initialize();
        }
    }
}
