using System.Collections.ObjectModel;

using GameStore.BLL.Dto;
using GameStore.BLL.Interfaces;

using WpfDemoApp.Extensions;

namespace WpfDemoApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IGamesService _gamesService;

        public MainPageViewModel(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public void Initialize()
        {
            Games = _gamesService.GetAll().ToObservableCollection();
        }

        public ObservableCollection<GameDto> Games { get; private set; }
    }
}
