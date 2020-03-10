using System.Collections.Generic;

using GameStore.BLL.Dto;

namespace GameStore.BLL.Interfaces
{
    public interface IGamesService
    {
        IEnumerable<GameDto> GetAll();
        GameDto Get(int id);
        void Create(GameDto game);
        void Update(GameDto game);
        void Delete(GameDto game);
    }
}
