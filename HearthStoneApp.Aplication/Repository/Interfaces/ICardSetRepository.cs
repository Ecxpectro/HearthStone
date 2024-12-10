using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Repository.Interfaces
{
    public interface ICardSetRepository
    {
        Task<CardSet> AddAsync(CardSet cardSet);
        Task<CardSet> GetCardSetByNameAsync(string name);
    }
}
