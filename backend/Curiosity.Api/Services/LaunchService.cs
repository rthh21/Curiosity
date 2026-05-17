using Curiosity.Api.DTOs;
using Curiosity.Api.Entities;
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
                RocketName = l.Rocket?.Name ?? "Unknown Rocket",
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

        public async Task<IEnumerable<LaunchDto>> GetPastLaunchesAsync()
        {
            var launches = await _repository.GetPastLaunchesAsync();

            return launches.Select(l => new LaunchDto
            {
                Id = l.Id,
                LaunchDate = l.LaunchDate,
                RocketName = l.Rocket?.Name ?? "Unknown Rocket",
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

        public async Task CreateLaunchAsync(CreateLaunchDto dto)
        {
            var launch = new Launch
            {
                MissionId = dto.MissionId,
                RocketId = dto.RocketId,
                LaunchDate = dto.LaunchDate,
                LaunchLocation = dto.LaunchLocation,
                FlightStatus = dto.FlightStatus,
                LiveStreamUrl = dto.LiveStreamUrl,
                IsFeatured = dto.IsFeatured
            };

            await _repository.AddAsync(launch);
            await _repository.SaveChangesAsync();
        }
    }
}
