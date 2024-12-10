using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class RarityService : IRarityService
    {
        private readonly IRarityRepository _rarityRepository;
        private readonly IMapper _mapper;

        public RarityService(IRarityRepository rarityRepository, IMapper mapper)
        {
            _rarityRepository = rarityRepository;
            _mapper = mapper;
        }
        public async Task<RarityDto> CreateRarityAsync(RarityDto rarityDto)
        {
            var rarity = _mapper.Map<Rarity>(rarityDto);

            var rarityAfterSave = await _rarityRepository.AddAsync(rarity);

            rarityDto.RarityId = rarityAfterSave.RarityId;
            return rarityDto;
        }

        public async Task<RarityDto> GetRarityByNameAsync(string name)
        {
            var rarity = await _rarityRepository.GetRarityByNameAsync(name);
            if (rarity == null) return null;

            return _mapper.Map<RarityDto>(rarity);
        }
    }
}
