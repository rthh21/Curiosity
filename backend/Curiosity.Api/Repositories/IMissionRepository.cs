using Curiosity.Api.Entities;

namespace Curiosity.Api.Repositories
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>> GetAllMissionsAsync();
        Task AddMissionAsync(Mission mission);
        Task<Mission?> GetMissionByIdAsync(int id);
        Task AddFavoriteAsync(UserFavoriteMission favorite);
        Task RemoveFavoriteAsync(string userId, int missionId);
        Task<IEnumerable<Mission>> GetUserFavoritesAsync(string userId);
        Task SaveChangesAsync();
    }
}