using HearthStoneApp.Aplication.Dtos;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface IPlayerClassService
    {
        Task<PlayerClassDto> CreatePlayerClassAsync(PlayerClassDto playerClassDto);
        Task<PlayerClassDto> GetPlayerClassByNameAsync(string name);
    }
}
