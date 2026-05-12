using Curiosity.Api.Data;
using Curiosity.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curiosity.Api.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AppDbContext _context;

        public AgencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agency>> GetAllAsync()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<Agency?> GetByIdAsync(int id)
        {
            return await _context.Agencies
                .Include(a => a.Missions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Agency agency)
        {
            await _context.Agencies.AddAsync(agency);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
