using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Repository.Interfaces
{
    public interface IRarityRepository
    {
        Task<Rarity> AddAsync(Rarity rarity);
        Task<Rarity> GetRarityByNameAsync(string name);
    }
}
