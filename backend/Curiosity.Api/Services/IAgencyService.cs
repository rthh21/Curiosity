using Curiosity.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curiosity.Api.Services
{
    public interface IAgencyService
    {
        Task<IEnumerable<AgencyDto>> GetAllAgenciesAsync();
        Task<AgencyDto?> GetAgencyByIdAsync(int id);
        Task CreateAgencyAsync(CreateAgencyDto dto);
    }
}
