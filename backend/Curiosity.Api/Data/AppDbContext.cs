using Curiosity.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Curiosity.Api.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Launch> Launches { get; set; }
        public DbSet<UserFavoriteMission> UserFavoriteMissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFavoriteMission>()
                .HasKey(ufm => new { ufm.UserId, ufm.MissionId });

            builder.Entity<UserFavoriteMission>()
                .HasOne(ufm => ufm.User)
                .WithMany(u => u.FavoriteMissions)
                .HasForeignKey(ufm => ufm.UserId);

            builder.Entity<UserFavoriteMission>()
                .HasOne(ufm => ufm.Mission)
                .WithMany(m => m.FavoritedByUsers)
                .HasForeignKey(ufm => ufm.MissionId);
        }
    }
}