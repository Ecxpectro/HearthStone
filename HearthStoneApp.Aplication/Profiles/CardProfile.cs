using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardDto, Card>().ForMember(dest => dest.CardSet, opt => opt.Ignore())
    .ForMember(dest => dest.Rarity, opt => opt.Ignore())
    .ForMember(dest => dest.PlayerClass, opt => opt.Ignore())
    .ForMember(dest => dest.Artist, opt => opt.Ignore());
            CreateMap<Card, CardDto>().ForMember(dest => dest.CardSetDto, opt => opt.MapFrom(src => src.CardSet))
    .ForMember(dest => dest.RarityDto, opt => opt.MapFrom(src => src.Rarity))
    .ForMember(dest => dest.PlayerClassDto, opt => opt.MapFrom(src => src.PlayerClass))
    .ForMember(dest => dest.ArtistDto, opt => opt.MapFrom(src => src.Artist))
    .ForMember(dest => dest.CardSet, opt => opt.Ignore())
    .ForMember(dest => dest.Rarity, opt => opt.Ignore())
    .ForMember(dest => dest.PlayerClass, opt => opt.Ignore())
    .ForMember(dest => dest.Artist, opt => opt.Ignore());
        }
    }
}
