using HearthStoneApp.Aplication.Dtos;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface IArtistService
    {
        Task<ArtistDto> CreateArtistAsync(ArtistDto artistDto);
        Task<ArtistDto> GetArtistByNameAsync(string name);
    }
}
