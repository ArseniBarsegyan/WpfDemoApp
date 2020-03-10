using AutoMapper;

using GameStore.BLL.Dto;
using GameStore.DAL.Models;

namespace GameStore.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<Developer, DeveloperDto>();
            CreateMap<DeveloperDto, Developer>();
        }
    }
}
