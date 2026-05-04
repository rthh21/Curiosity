using Curiosity.Api.DTOs;

namespace Curiosity.Api.Services
{
    public interface ILaunchService
    {
        Task<IEnumerable<LaunchDto>> GetUpcomingLaunchesAsync();
    }
}
