using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardDto>> GetCardsAsync()
        {
            var cards = await _cardRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CardDto>>(cards);
            return result;
        }

        public async Task<CardDto> GetCardAsync(long id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null) return null;

            return _mapper.Map<CardDto>(card);
        }

        public async Task<CardDto> CreateCardAsync(CardDto cardDto)
        {
            var card = _mapper.Map<Card>(cardDto);

            await _cardRepository.AddAsync(card);
            return cardDto; 
        }

        public async Task<CardDto> UpdateCardAsync(CardDto cardDto)
        {
            var card = await _cardRepository.GetByIdAsync(cardDto.Id);
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

        public async Task<CardDto> UpsertCardAsync(CardDto cardDto)
        {
            var card = _mapper.Map<Card>(cardDto);

            await _cardRepository.UpsertCardAsync(card);

            return cardDto;
        }
    }
}
