using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using HearthStoneApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Aplication.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly HearthStoneDbContext _context;

        public ArtistRepository(HearthStoneDbContext context)
        {
            _context = context;
        }
        public async Task<Artist> AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        public async Task<Artist> GetArtistByNameAsync(string name) => await _context.Artists.FirstOrDefaultAsync(x => x.Name == name);
    }
}
