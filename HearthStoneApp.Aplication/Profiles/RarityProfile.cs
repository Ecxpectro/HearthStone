using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Profiles
{
    public class RarityProfile : Profile
    {
        public RarityProfile()
        {
            CreateMap<RarityDto, Rarity>().ReverseMap();

        }
    }
}
