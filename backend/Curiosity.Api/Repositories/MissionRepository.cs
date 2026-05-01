using Curiosity.Api.Data;
using Curiosity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curiosity.Api.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly AppDbContext _context;

        public MissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mission>> GetAllMissionsAsync()
        {
            // Includem și Agenția pentru a-i putea afișa numele în DTO
            return await _context.Missions.Include(m => m.Agency).ToListAsync();
        }

        public async Task AddMissionAsync(Mission mission)
        {
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();
        }
    }
}