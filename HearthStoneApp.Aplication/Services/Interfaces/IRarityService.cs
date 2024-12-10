using HearthStoneApp.Aplication.Dtos;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface IRarityService
    {
        Task<RarityDto> CreateRarityAsync(RarityDto rarityDto);
        Task<RarityDto> GetRarityByNameAsync(string name);
    }
}
