using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Repository.Interfaces
{
    public interface IPlayerClassRepository
    {
        Task<PlayerClass> AddAsync(PlayerClass playerClass);
        Task<PlayerClass> GetPlayerClassByNameAsync(string name);
    }
}
