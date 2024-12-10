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
        private readonly IArtistService _artistService;

        public CardSyncJob(IHearthStoneApiService apiService, ICardService cardService, IRarityService rarityService, IArtistService artistService)
        {
            _apiService = apiService;
            _cardService = cardService;
            _rarityService = rarityService;
            _artistService = artistService;
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

                            if (!string.IsNullOrEmpty(cardDto.Artist))
                            {
                                cardDto.ArtistId = await GetOrCreateArtistIdAsync(cardDto.Artist);
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
        private async Task<long> GetOrCreateArtistIdAsync(string artistName)
        {
            var artist = await _artistService.GetArtistByNameAsync(artistName);
            if (artist == null)
            {
                artist = await _artistService.CreateArtistAsync(new ArtistDto { Name = artistName });
            }
            return artist.ArtistId;
        }
    }
}
