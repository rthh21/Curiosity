using Curiosity.Api.DTOs;
using Curiosity.Api.Entities;
using Curiosity.Api.Repositories;

namespace Curiosity.Api.Services
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository _repository;

        public MissionService(IMissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MissionDto>> GetAllMissionsAsync()
        {
            var missions = await _repository.GetAllMissionsAsync();
            
            // Mapare simplă din Entitate în DTO
            return missions.Select(m => new MissionDto
            {
                Id = m.Id,
                Title = m.Title,
                PayloadDescription = m.PayloadDescription,
                ImageUrl = m.ImageUrl,
                AgencyName = m.Agency?.Name ?? "Necunoscut"
            });
        }

        public async Task CreateMissionAsync(CreateMissionDto dto)
        {
            var mission = new Mission
            {
                Title = dto.Title,
                PayloadDescription = dto.PayloadDescription,
                NewsArticleBody = dto.NewsArticleBody,
                AgencyId = dto.AgencyId
            };

            await _repository.AddMissionAsync(mission);
        }
    }
}