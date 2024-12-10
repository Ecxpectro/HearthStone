using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Repository.Interfaces
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card> GetByIdAsync(long id);
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(Card card);
    }
}
