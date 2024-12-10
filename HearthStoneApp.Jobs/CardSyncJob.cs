using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.WorkerService.Services.Interfaces;
using Newtonsoft.Json;

namespace HearthStoneApp.Jobs
{
    public class CardSyncJob
    {
        private readonly IHearthStoneApiService _apiService;
        private readonly ICardService _cardService;

        public CardSyncJob(IHearthStoneApiService apiService, ICardService cardService)
        {
            _apiService = apiService;
            _cardService = cardService;
        }

        public async Task SyncCardsAsync()
        {
            var jsonResponse = await _apiService.GetCardsAsync();

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                var cardDtos = JsonConvert.DeserializeObject<List<CardDto>>(jsonResponse);
                if (cardDtos != null)
                {
                    foreach (var cardDto in cardDtos)
                    {
                        await _cardService.CreateCardAsync(cardDto);
                    }
                }
            }
        }
    }
}
