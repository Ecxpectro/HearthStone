using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<ArtistDto, Artist>().ReverseMap();
        }
    }
}
