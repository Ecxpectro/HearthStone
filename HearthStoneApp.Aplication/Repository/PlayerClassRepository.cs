using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using HearthStoneApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Aplication.Repository
{
    public class PlayerClassRepository : IPlayerClassRepository
    {
        private readonly HearthStoneDbContext _context;

        public PlayerClassRepository(HearthStoneDbContext context)
        {
            _context = context;
        }
        public async Task<PlayerClass> AddAsync(PlayerClass playerClass)
        {
            await _context.PlayerClasses.AddAsync(playerClass);
            await _context.SaveChangesAsync();

            return playerClass;
        }

        public async Task<PlayerClass> GetPlayerClassByNameAsync(string name) => await _context.PlayerClasses.FirstOrDefaultAsync(x => x.Name == name);
    }
}
