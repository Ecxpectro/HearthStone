using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using HearthStoneApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Aplication.Repository
{
    public class RarityRepository : IRarityRepository
    {
        private readonly HearthStoneDbContext _context;

        public RarityRepository(HearthStoneDbContext context)
        {
            _context = context;
        }
        public async Task<Rarity> AddAsync(Rarity rarity)
        {
            await _context.Rarities.AddAsync(rarity);
            await _context.SaveChangesAsync();

            return rarity;
        }

        public async Task<Rarity> GetRarityByNameAsync(string name) => await _context.Rarities.FirstOrDefaultAsync(x => x.Name == name);
    }
}
