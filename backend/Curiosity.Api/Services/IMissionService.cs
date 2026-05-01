using Curiosity.Api.DTOs;

namespace Curiosity.Api.Services
{
    public interface IMissionService
    {
        Task<IEnumerable<MissionDto>> GetAllMissionsAsync();
        Task CreateMissionAsync(CreateMissionDto dto);
        Task<MissionDto> GetMissionByIdAsync(int id);
    }
}