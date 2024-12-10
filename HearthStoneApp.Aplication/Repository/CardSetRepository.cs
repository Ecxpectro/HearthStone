using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using HearthStoneApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Aplication.Repository
{
    public class CardSetRepository : ICardSetRepository
    {
        private readonly HearthStoneDbContext _context;

        public CardSetRepository(HearthStoneDbContext context)
        {
            _context = context;
        }
        public async Task<CardSet> AddAsync(CardSet cardSet)
        {
            await _context.CardSets.AddAsync(cardSet);
            await _context.SaveChangesAsync();

            return cardSet;
        }

        public async Task<CardSet> GetCardSetByNameAsync(string name) => await _context.CardSets.FirstOrDefaultAsync(x => x.Name == name);
    }
}
