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
                NewsArticleBody = m.NewsArticleBody,
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
                ImageUrl = dto.ImageUrl,
                AgencyId = dto.AgencyId
            };

            await _repository.AddMissionAsync(mission);
        }

        public async Task<MissionDto> GetMissionByIdAsync(int id)
        {
            var mission = await _repository.GetMissionByIdAsync(id);

            if (mission == null)
            {
                // Această eroare va fi prinsă de ExceptionHandlingMiddleware
                // și transformată automat în cod 404 (Not Found)
                throw new KeyNotFoundException($"Misiunea cu ID-ul {id} nu există.");
            }

            return new MissionDto
            {
                Id = mission.Id,
                Title = mission.Title,
                PayloadDescription = mission.PayloadDescription,
                NewsArticleBody = mission.NewsArticleBody,
                ImageUrl = mission.ImageUrl,
                AgencyName = mission.Agency?.Name ?? "N/A"
            };
        }

        public async Task AddToFavoritesAsync(string userId, int missionId)
        {
            var favorite = new UserFavoriteMission
            {
                UserId = userId,
                MissionId = missionId
            };
            await _repository.AddFavoriteAsync(favorite);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveFromFavoritesAsync(string userId, int missionId)
        {
            await _repository.RemoveFavoriteAsync(userId, missionId);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MissionDto>> GetUserFavoritesAsync(string userId)
        {
            var missions = await _repository.GetUserFavoritesAsync(userId);
            return missions.Select(m => new MissionDto
            {
                Id = m.Id,
                Title = m.Title,
                PayloadDescription = m.PayloadDescription,
                NewsArticleBody = m.NewsArticleBody,
                ImageUrl = m.ImageUrl,
                AgencyName = m.Agency?.Name ?? "N/A"
            });
        }
    }

}
