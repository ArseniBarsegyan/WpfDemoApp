using System.Collections.Generic;

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
            var entity = _mapper.Map<GameDto, Game>(game);
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
            return _mapper.Map<Game, GameDto>(_repository.GetById(id));
        }

        public IEnumerable<GameDto> GetAll()
        {
            var entities = _repository.GetAll();
            foreach (var entity in entities)
            {
                yield return _mapper.Map<Game, GameDto>(entity);
            }
        }

        public void Update(GameDto game)
        {
            _repository.Update(_mapper.Map<GameDto, Game>(game));
        }
    }
}
