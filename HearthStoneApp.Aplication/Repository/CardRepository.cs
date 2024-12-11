using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Domain.Entities;
using HearthStoneApp.Infrastructure.Data;
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
            return await _context.Cards.AsNoTracking().ToListAsync();
        }

        public async Task<Card> GetByIdAsync(long id)
        {
            return await _context.Cards.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<bool> UpsertCardAsync(Card card)
        {
            var existingCard = await _context.Cards.FirstOrDefaultAsync(x => x.Name == card.Name);
            if (existingCard == null)
            {
                _context.Cards.Add(card);
            }
            else
            {
                card.Id = existingCard.Id;
                _context.Entry(existingCard).CurrentValues.SetValues(card);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Card> GetAllCards()
        {
            return _context.Cards
                .AsNoTracking()
             .Include(c => c.Rarity)
             .Include(c => c.PlayerClass)
             .Include(c => c.Artist)
             .Include(c => c.CardSet);
        }
    }
}
