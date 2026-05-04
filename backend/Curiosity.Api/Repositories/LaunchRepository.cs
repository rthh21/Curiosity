using Curiosity.Api.Data;
using Curiosity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curiosity.Api.Repositories
{
    public class LaunchRepository : ILaunchRepository
    {
        private readonly AppDbContext _context;

        public LaunchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Launch>> GetUpcomingLaunchesAsync()
        {
            return await _context.Launches
                .Include(l => l.Mission)
                    .ThenInclude(m => m!.Agency)
                .Where(l => l.LaunchDate >= DateTime.UtcNow)
                .OrderBy(l => l.LaunchDate)
                .ToListAsync();
        }

        public async Task<Launch?> GetLaunchByIdAsync(int id)
        {
            return await _context.Launches
                .Include(l => l.Mission)
                    .ThenInclude(m => m!.Agency)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
