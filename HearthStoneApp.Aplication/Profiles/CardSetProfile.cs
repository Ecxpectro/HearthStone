using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Profiles
{
    public class CardSetProfile : Profile
    {
        public CardSetProfile()
        {
            CreateMap<CardSetDto, CardSet>().ReverseMap();

        }
    }
}
