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
        
        public async Task<Mission?> GetMissionByIdAsync(int id)
        {
            return await _context.Missions
                .Include(m => m.Agency)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddFavoriteAsync(UserFavoriteMission favorite)
        {
            await _context.UserFavoriteMissions.AddAsync(favorite);
        }

        public async Task RemoveFavoriteAsync(string userId, int missionId)
        {
            var fav = await _context.UserFavoriteMissions
                .FirstOrDefaultAsync(f => f.UserId == userId && f.MissionId == missionId);
            if (fav != null)
            {
                _context.UserFavoriteMissions.Remove(fav);
            }
        }

        public async Task<IEnumerable<Mission>> GetUserFavoritesAsync(string userId)
        {
            return await _context.UserFavoriteMissions
                .Where(f => f.UserId == userId)
                .Include(f => f.Mission)
                .ThenInclude(m => m!.Agency)
                .Select(f => f.Mission!)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}