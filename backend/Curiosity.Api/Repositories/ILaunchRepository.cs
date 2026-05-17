using Curiosity.Api.Entities;

namespace Curiosity.Api.Repositories
{
    public interface ILaunchRepository
    {
        Task<IEnumerable<Launch>> GetUpcomingLaunchesAsync();
        Task<IEnumerable<Launch>> GetPastLaunchesAsync();
        Task<Launch?> GetLaunchByIdAsync(int id);
        Task AddAsync(Launch launch);
        Task SaveChangesAsync();
    }
}
