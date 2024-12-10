using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<CardDto>> GetCardsAsync()
        {
            var cards = await _cardRepository.GetAllAsync();
            return cards.Select(c => new CardDto
            {
                CardId = c.CardId,
                Name = c.Name,
                Type = c.Type,
                Cost = c.Cost,
                Attack = c.Attack,
                Health = c.Health,
                Text = c.Text,
                Flavor = c.Flavor,
                ImgUrl = c.ImgUrl
            });
        }

        public async Task<CardDto> GetCardAsync(long id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null) return null;

            return new CardDto
            {
                CardId = card.CardId,
                Name = card.Name,
                Type = card.Type,
                Cost = card.Cost,
                Attack = card.Attack,
                Health = card.Health,
                Text = card.Text,
                Flavor = card.Flavor,
                ImgUrl = card.ImgUrl
            };
        }

        public async Task<CardDto> CreateCardAsync(CardDto cardDto)
        {
            var card = new Card
            {
                Name = cardDto.Name,
                Type = cardDto.Type,
                Cost = cardDto.Cost,
                Attack = cardDto.Attack,
                Health = cardDto.Health,
                Text = cardDto.Text,
                Flavor = cardDto.Flavor,
                ImgUrl = cardDto.ImgUrl
            };

            await _cardRepository.AddAsync(card);
            return cardDto; 
        }

        public async Task<CardDto> UpdateCardAsync(CardDto cardDto)
        {
            var card = await _cardRepository.GetByIdAsync(cardDto.CardId);
            if (card == null) return null;

            card.Name = cardDto.Name;
            card.Type = cardDto.Type;
            card.Cost = cardDto.Cost;
            card.Attack = cardDto.Attack;
            card.Health = cardDto.Health;
            card.Text = cardDto.Text;
            card.Flavor = cardDto.Flavor;
            card.ImgUrl = cardDto.ImgUrl;

            await _cardRepository.UpdateAsync(card);
            return cardDto;
        }

        public async Task<bool> DeleteCardAsync(long id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null) return false;

            await _cardRepository.DeleteAsync(card);
            return true;
        }
    }
}
