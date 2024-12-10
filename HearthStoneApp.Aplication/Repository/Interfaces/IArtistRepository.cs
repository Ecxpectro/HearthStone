using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Repository.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> AddAsync(Artist artist);
        Task<Artist> GetArtistByNameAsync(string name);
    }
}
