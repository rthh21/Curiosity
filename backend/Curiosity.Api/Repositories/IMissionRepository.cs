using Curiosity.Api.Entities;

namespace Curiosity.Api.Repositories
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>> GetAllMissionsAsync();
        Task AddMissionAsync(Mission mission);
        Task<Mission?> GetMissionByIdAsync(int id);
    }
}