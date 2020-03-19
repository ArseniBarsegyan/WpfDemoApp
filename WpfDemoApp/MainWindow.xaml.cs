using System;
using System.Windows;

using GameStore.BLL.Interfaces;

namespace WpfDemoApp
{
    public partial class MainWindow : Window
    {
        private readonly IGamesService _gamesService;

        public MainWindow(IGamesService gamesService)
        {
            InitializeComponent();
            _gamesService = gamesService;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            GamesList.ItemsSource = _gamesService.GetAll();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var createGameWindow = new CreateGameWindow(_gamesService);
            createGameWindow.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
