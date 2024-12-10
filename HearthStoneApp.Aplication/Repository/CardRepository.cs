using HearthStoneApp.Aplication.Data;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Aplication.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly HearthStoneDbContext _context;

        public CardRepository(HearthStoneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetByIdAsync(long id)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.CardId == id);
        }

        public async Task AddAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}
