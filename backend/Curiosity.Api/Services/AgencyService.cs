using Curiosity.Api.DTOs;
using Curiosity.Api.Entities;
using Curiosity.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiosity.Api.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _repository;

        public AgencyService(IAgencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AgencyDto>> GetAllAgenciesAsync()
        {
            var agencies = await _repository.GetAllAsync();
            return agencies.Select(a => new AgencyDto
            {
                Id = a.Id,
                Name = a.Name,
                Country = a.Country,
                Description = a.Description,
                LogoUrl = a.LogoUrl
            });
        }

        public async Task<AgencyDto?> GetAgencyByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new AgencyDto
            {
                Id = a.Id,
                Name = a.Name,
                Country = a.Country,
                Description = a.Description,
                LogoUrl = a.LogoUrl
            };
        }

        public async Task CreateAgencyAsync(CreateAgencyDto dto)
        {
            var agency = new Agency
            {
                Name = dto.Name,
                Country = dto.Country,
                Description = dto.Description,
                LogoUrl = dto.LogoUrl
            };

            await _repository.AddAsync(agency);
            await _repository.SaveChangesAsync();
        }
    }
}
