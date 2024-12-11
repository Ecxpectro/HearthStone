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
        private readonly IPlayerClassService _playerClassService;
        private readonly ICardSetService _cardSetService;
        private readonly ILogger<CardSyncJob> _logger;

        public CardSyncJob(IHearthStoneApiService apiService, ICardService cardService, IRarityService rarityService, IArtistService artistService, IPlayerClassService playerClassService, ICardSetService cardSetService, ILogger<CardSyncJob> logger)
        {
            _apiService = apiService;
            _cardService = cardService;
            _rarityService = rarityService;
            _artistService = artistService;
            _playerClassService = playerClassService;
            _cardSetService = cardSetService;
            _logger = logger;
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
                            if (!string.IsNullOrEmpty(cardDto.PlayerClass))
                            {
                                cardDto.PlayerClassId = await GetOrCreatePlayerClassIdAsync(cardDto.PlayerClass);
                            } 
                            if (!string.IsNullOrEmpty(cardDto.CardSet))
                            {
                                cardDto.CardSetId = await GetOrCreateCardSetIdAsync(cardDto.CardSet);
                            }
                            await _cardService.UpsertCardAsync(cardDto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while syncing cards.");
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
        private async Task<long?> GetOrCreatePlayerClassIdAsync(string playerClassName)
        {
            var playerClass = await _playerClassService.GetPlayerClassByNameAsync(playerClassName);
            if (playerClass == null)
            {
                playerClass = await _playerClassService.CreatePlayerClassAsync(new PlayerClassDto { Name = playerClassName });
            }
            return playerClass.PlayerClassId;
        }
        private async Task<long?> GetOrCreateCardSetIdAsync(string cardSetName)
        {
            var cardSet = await _cardSetService.GetCardSetByNameAsync(cardSetName);
            if (cardSet == null)
            {
                cardSet = await _cardSetService.CreateCardSetAsync(new CardSetDto { Name = cardSetName });
            }
            return cardSet.CardSetId;
        }
    }
}
