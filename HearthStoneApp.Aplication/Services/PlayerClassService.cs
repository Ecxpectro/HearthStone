using AutoMapper;
using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Repository;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Domain.Entities;

namespace HearthStoneApp.Aplication.Services
{
    public class PlayerClassService : IPlayerClassService
    {
        private readonly IPlayerClassRepository _playerClassRepository;
        private readonly IMapper _mapper;

        public PlayerClassService(IPlayerClassRepository playerClassRepository, IMapper mapper)
        {
            _playerClassRepository = playerClassRepository;
            _mapper = mapper;
        }
        public async Task<PlayerClassDto> CreatePlayerClassAsync(PlayerClassDto playerClassDto)
        {
            var playerClass = _mapper.Map<PlayerClass>(playerClassDto);

            var playerClassAfterSave = await _playerClassRepository.AddAsync(playerClass);

            playerClassDto.PlayerClassId = playerClassAfterSave.PlayerClassId;

            return playerClassDto;
        }

        public async Task<PlayerClassDto> GetPlayerClassByNameAsync(string name)
        {
            var playerClass = await _playerClassRepository.GetPlayerClassByNameAsync(name);
            if (playerClass == null) return null;

            return _mapper.Map<PlayerClassDto>(playerClass);
        }
    }
}
