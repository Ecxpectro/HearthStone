using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }
        public async Task<ArtistDto> CreateArtistAsync(ArtistDto artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);

            var artistAfterSave = await _artistRepository.AddAsync(artist);

            artistDto.ArtistId = artistAfterSave.ArtistId;
            return artistDto;
        }

        public async Task<ArtistDto> GetArtistByNameAsync(string name)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(name);
            if (artist == null) return null;

            return _mapper.Map<ArtistDto>(artist);
        }
    }
}
