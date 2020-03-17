using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using GameStore.BLL.Dto;
using GameStore.BLL.Interfaces;
using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.DAL.Repositories;

namespace GameStore.BLL.Classes
{
    public class GamesService : IGamesService
    {
        private readonly Repository<GameStoreContext, Game> _repository;
        private readonly IMapper _mapper;

        public GamesService(IMapper mapper, 
            Repository<GameStoreContext, Game> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(GameDto game)
        {
            var entity = _mapper.Map<Game>(game);
            _repository.Create(entity);
            _repository.Save();
        }

        public void Delete(GameDto game)
        {
            _repository.Delete(game.Id);
            _repository.Save();
        }

        public GameDto Get(int id)
        {
            return _mapper.Map<GameDto>(_repository.GetById(id));
        }

        public IEnumerable<GameDto> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Select(x => _mapper.Map<GameDto>(x));
        }

        public void Update(GameDto game)
        {
            _repository.Update(_mapper.Map<Game>(game));
        }
    }
}
