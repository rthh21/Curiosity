using Curiosity.Api.DTOs;
using Curiosity.Api.Repositories;

namespace Curiosity.Api.Services
{
    public class LaunchService : ILaunchService
    {
        private readonly ILaunchRepository _repository;

        public LaunchService(ILaunchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LaunchDto>> GetUpcomingLaunchesAsync()
        {
            var launches = await _repository.GetUpcomingLaunchesAsync();

            return launches.Select(l => new LaunchDto
            {
                Id = l.Id,
                LaunchDate = l.LaunchDate,
                RocketName = l.RocketName,
                FlightStatus = l.FlightStatus,
                LiveStreamUrl = l.LiveStreamUrl,
                LaunchLocation = l.LaunchLocation,
                IsFeatured = l.IsFeatured,
                MissionTitle = l.Mission?.Title ?? "Unknown Mission",
                MissionDescription = l.Mission?.PayloadDescription ?? "",
                MissionImageUrl = l.Mission?.ImageUrl,
                AgencyName = l.Mission?.Agency?.Name ?? "Unknown"
            });
        }
    }
}
