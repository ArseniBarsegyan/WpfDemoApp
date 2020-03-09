using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.DAL.Repositories;

namespace WpfDemoApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly Repository<GameStoreContext, Game> _repository;

        public MainPageViewModel(Repository<GameStoreContext, Game> repository)
        {
            _repository = repository;
            var allGames = _repository.Get();
        }
    }
}
