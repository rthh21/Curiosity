using Curiosity.Api.DTOs;

namespace Curiosity.Api.Services
{
    public interface IMissionService
    {
        Task<IEnumerable<MissionDto>> GetAllMissionsAsync();
        Task CreateMissionAsync(CreateMissionDto dto);
        Task<MissionDto> GetMissionByIdAsync(int id);
        Task AddToFavoritesAsync(string userId, int missionId);
        Task RemoveFromFavoritesAsync(string userId, int missionId);
        Task<IEnumerable<MissionDto>> GetUserFavoritesAsync(string userId);
    }
}