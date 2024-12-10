using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Profiles
{
    internal class PlayerClassProfile : Profile
    {
        public PlayerClassProfile()
        {
            CreateMap<PlayerClassDto, PlayerClass>().ReverseMap();

        }
    }
}
