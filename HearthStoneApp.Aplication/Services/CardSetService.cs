using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class CardSetService : ICardSetService
    {
        private readonly ICardSetRepository _cardSetRepository;
        private readonly IMapper _mapper;

        public CardSetService(ICardSetRepository cardSetRepository, IMapper mapper)
        {
            _cardSetRepository = cardSetRepository;
            _mapper = mapper;
        }
        public async Task<CardSetDto> CreateCardSetAsync(CardSetDto cardSetDto)
        {
            var cardSet = _mapper.Map<CardSet>(cardSetDto);

            var cardSetAfterSave = await _cardSetRepository.AddAsync(cardSet);

            cardSetDto.CardSetId = cardSetAfterSave.CardSetId;

            return cardSetDto;
        }

        public async Task<CardSetDto> GetCardSetByNameAsync(string name)
        {
            var cardSet = await _cardSetRepository.GetCardSetByNameAsync(name);
            if (cardSet == null) return null;

            return _mapper.Map<CardSetDto>(cardSet);
        }
    }
}
