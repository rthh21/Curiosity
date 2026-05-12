using Curiosity.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curiosity.Api.Repositories
{
    public interface IAgencyRepository
    {
        Task<IEnumerable<Agency>> GetAllAsync();
        Task<Agency?> GetByIdAsync(int id);
        Task AddAsync(Agency agency);
        Task SaveChangesAsync();
    }
}
