using Curiosity.Api.DTOs;
using Curiosity.Api.Entities;

namespace Curiosity.Api.Repositories
{
    public interface ILaunchRepository
    {
        Task<IEnumerable<Launch>> GetUpcomingLaunchesAsync();
        Task<Launch?> GetLaunchByIdAsync(int id);
    }
}
