using HearthStoneApp.Aplication.Dtos;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetCardsAsync();
        Task<CardDto> GetCardAsync(long id);
        Task<CardDto> CreateCardAsync(CardDto cardDto);
        Task<CardDto> UpdateCardAsync(CardDto cardDto);
        Task<bool> DeleteCardAsync(long id);
    }
}
