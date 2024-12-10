using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.WorkerService.Interfaces;
using HearthStoneApp.WorkerService.Services.Interfaces;
using Newtonsoft.Json;

namespace HearthStoneApp.WorkerService
{
    public class CardSyncJob : ICardSyncJob
    {
        private readonly IHearthStoneApiService _apiService;
        private readonly ICardService _cardService;
        private readonly IRarityService _rarityService;

        public CardSyncJob(IHearthStoneApiService apiService, ICardService cardService, IRarityService rarityService)
        {
            _apiService = apiService;
            _cardService = cardService;
            _rarityService = rarityService;
        }

        public async Task SyncCardsAsync()
        {
            try
            {
                var jsonResponse = await _apiService.GetCardsAsync();

                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    var cardDtos = JsonConvert.DeserializeObject<List<CardDto>>(jsonResponse);
                    if (cardDtos != null)
                    {
                        RarityDto rarity = new RarityDto();
                        foreach (var cardDto in cardDtos)
                        {
                            if (!string.IsNullOrEmpty(cardDto.Rarity))
                            {
                                cardDto.RarityId = await GetOrCreateRarityIdAsync(cardDto.Rarity);
                            }
                            await _cardService.UpsertCardAsync(cardDto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private async Task<long> GetOrCreateRarityIdAsync(string rarityName)
        {
            var rarity = await _rarityService.GetRarityByNameAsync(rarityName);
            if (rarity == null)
            {
                rarity = await _rarityService.CreateRarityAsync(new RarityDto { Name = rarityName });
            }
            return rarity.RarityId;
        }
    }
}
