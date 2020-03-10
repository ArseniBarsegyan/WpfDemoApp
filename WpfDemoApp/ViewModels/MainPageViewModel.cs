using GameStore.BLL.Interfaces;

namespace WpfDemoApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IGamesService _gamesService;

        public MainPageViewModel(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
    }
}
