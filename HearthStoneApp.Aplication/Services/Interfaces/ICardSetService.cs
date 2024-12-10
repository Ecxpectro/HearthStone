using HearthStoneApp.Aplication.Dtos;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface ICardSetService
    {
        Task<CardSetDto> CreateCardSetAsync(CardSetDto cardSetDto);
        Task<CardSetDto> GetCardSetByNameAsync(string name);
    }
}
