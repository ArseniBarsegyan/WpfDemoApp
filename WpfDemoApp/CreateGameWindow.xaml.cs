using System.Windows;

using GameStore.BLL.Dto;
using GameStore.BLL.Interfaces;

namespace WpfDemoApp
{
    public partial class CreateGameWindow : Window
    {
        private readonly IGamesService _gamesService;

        public CreateGameWindow(IGamesService gamesService)
        {
            InitializeComponent();
            _gamesService = gamesService;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var gameDto = new GameDto
            {
                Name = TitleTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text,
                Price = int.Parse(PriceTextBox.Text),
                ReleaseDate = ReleaseDatePicker.SelectedDate.GetValueOrDefault()
            };
            _gamesService.Create(gameDto);
            NavigateBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack();
        }

        private void NavigateBack()
        {
            var window = new MainWindow(_gamesService);
            window.Show();
            Close();
        }
    }
}
