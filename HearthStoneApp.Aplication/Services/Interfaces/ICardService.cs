using HearthStoneApp.Aplication.Common;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Dtos.Filters;

namespace HearthStoneApp.Aplication.Services.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetCardsAsync();
        Task<CardDto> GetCardAsync(long id);
        Task<CardDto> CreateCardAsync(CardDto cardDto);
        Task<CardDto> UpdateCardAsync(CardDto cardDto);
        Task<bool> DeleteCardAsync(long id);
        Task<CardDto> UpsertCardAsync(CardDto cardDto);
        Task<PaginatedResult<CardDto>> GetFilteredCardsAsync(CardFilterDto filter);
    }
}
