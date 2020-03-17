using System.Collections.ObjectModel;

using GameStore.BLL.Dto;
using GameStore.BLL.Interfaces;

namespace WpfDemoApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IGamesService _gamesService;

        public MainPageViewModel(IGamesService gamesService)
        {
            _gamesService = gamesService;
            Games = new ObservableCollection<GameDto>();
        }

        public void Initialize()
        {
            var games = _gamesService.GetAll();
            Games.Clear();
            foreach(var game in games)
            {
                Games.Add(game);
            }
        }

        public ObservableCollection<GameDto> Games { get; private set; }
    }
}
