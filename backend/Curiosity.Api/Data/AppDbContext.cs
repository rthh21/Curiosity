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

            // Seed Agencies
            builder.Entity<Agency>().HasData(
                new Agency { Id = 1, Name = "NASA", Country = "USA", Description = "National Aeronautics and Space Administration.", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e5/NASA_logo.svg" },
                new Agency { Id = 2, Name = "SpaceX", Country = "USA", Description = "Space Exploration Technologies Corp.", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/d/de/SpaceX-Logo.svg" },
                new Agency { Id = 3, Name = "ESA", Country = "Europe", Description = "European Space Agency.", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6e/ESA_logo_simple.svg" },
                new Agency { Id = 4, Name = "CNSA", Country = "China", Description = "China National Space Administration.", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/b/b2/Insignia_of_CNSA.svg" },
                new Agency { Id = 5, Name = "ISRO", Country = "India", Description = "Indian Space Research Organisation.", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/b/bd/Indian_Space_Research_Organisation_Logo.svg" }
            );

            // Seed Missions
            builder.Entity<Mission>().HasData(
                new Mission { Id = 1, AgencyId = 1, Title = "James Webb Space Telescope", PayloadDescription = "Infrared astronomy mission to explore the early universe.", NewsArticleBody = "The James Webb Space Telescope (JWST) is a space telescope designed primarily to conduct infrared astronomy.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/JWST_spacecraft_model_3.png" },
                new Mission { Id = 2, AgencyId = 1, Title = "Europa Clipper", PayloadDescription = "Studying the Galilean moon Europa to investigate its habitability.", NewsArticleBody = "Europa Clipper will perform dozens of close flybys of Jupiter's moon Europa.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/59/Europa_Clipper_spacecraft_model.png" },
                new Mission { Id = 3, AgencyId = 3, Title = "JUICE", PayloadDescription = "Jupiter Icy Moons Explorer studying Ganymede, Callisto, and Europa.", NewsArticleBody = "JUICE will spend at least three years making detailed observations of Jupiter.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Juice_launch_kit_cover_close-up.png" },
                new Mission { Id = 4, AgencyId = 4, Title = "Chang'e 6", PayloadDescription = "Lunar sample return mission from the far side of the Moon.", NewsArticleBody = "The mission aims to collect samples from the South Pole-Aitken basin.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/cb/Chang%27e_6_lunar_samples_at_IAC_2024_01.jpg" },
                new Mission { Id = 5, AgencyId = 1, Title = "Artemis II", PayloadDescription = "First crewed mission of the Artemis program to orbit the Moon.", NewsArticleBody = "Artemis II is the first planned crewed mission of NASA's Artemis program.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/15/Earthset_%28art002e009288%29.jpg" },
                new Mission { Id = 6, AgencyId = 1, Title = "Artemis III", PayloadDescription = "Human return to the lunar surface.", NewsArticleBody = "Artemis III will be the first human mission to the lunar South Pole.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/19/Artemis_III_ESM3_Engine_Nozzle_Install_Completion_%28KSC-20260217-PH-JBS01_0002%29.jpg" },
                new Mission { Id = 7, AgencyId = 1, Title = "Lunar Gateway", PayloadDescription = "A lunar space station.", NewsArticleBody = "Gateway will serve as a multi-purpose outpost orbiting the Moon.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3c/Lunar_Gateway_rendering_2.webp" },
                new Mission { Id = 8, AgencyId = 1, Title = "Mars Sample Return", PayloadDescription = "Bringing Mars rocks to Earth.", NewsArticleBody = "MSR will collect and return Martian samples for the first time.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/07/Mars_sample_returnjpl.jpg" },
                new Mission { Id = 9, AgencyId = 1, Title = "Dragonfly", PayloadDescription = "Rotorcraft to explore Titan.", NewsArticleBody = "Dragonfly will explore the chemistry of Saturn's moon Titan.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Dragonfly_render_June_2025.png" },
                new Mission { Id = 10, AgencyId = 3, Title = "LISA", PayloadDescription = "Gravitational wave observatory.", NewsArticleBody = "LISA will detect gravitational waves from space.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f5/LISA-waves.jpg" }
            );

            // Seed Launches (Dates after May 2026)
            builder.Entity<Launch>().HasData(
                new Launch { Id = 1, MissionId = 1, RocketName = "Ariane 5 Post-Flight Support", LaunchDate = new DateTime(2026, 10, 15), LaunchLocation = "Kourou, French Guiana", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 2, MissionId = 2, RocketName = "Falcon Heavy - Clipper", LaunchDate = new DateTime(2026, 12, 10), LaunchLocation = "Kennedy Space Center, FL", FlightStatus = "Scheduled", IsFeatured = true },
                new Launch { Id = 3, MissionId = 3, RocketName = "Ariane 6 - JUICE Extended", LaunchDate = new DateTime(2027, 04, 14), LaunchLocation = "Kourou, French Guiana", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 4, MissionId = 4, RocketName = "Long March 5 Y8 - Lunar Support", LaunchDate = new DateTime(2027, 05, 03), LaunchLocation = "Wenchang, China", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 5, MissionId = 5, RocketName = "SLS Block 1 - Artemis 2", LaunchDate = new DateTime(2026, 11, 15), LaunchLocation = "Kennedy Space Center, FL", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 6, MissionId = 6, RocketName = "Starship HLS & SLS", LaunchDate = new DateTime(2026, 09, 15), LaunchLocation = "Kennedy Space Center / Starbase", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 7, MissionId = 7, RocketName = "Falcon Heavy - Gateway", LaunchDate = new DateTime(2027, 11, 01), LaunchLocation = "Kennedy Space Center, FL", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 8, MissionId = 8, RocketName = "SLS Block 1B - MSR", LaunchDate = new DateTime(2028, 08, 10), LaunchLocation = "Kennedy Space Center, FL", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 9, MissionId = 9, RocketName = "Heavy Lift Vehicle TBA", LaunchDate = new DateTime(2028, 07, 01), LaunchLocation = "TBA", FlightStatus = "Scheduled", IsFeatured = false },
                new Launch { Id = 10, MissionId = 10, RocketName = "Ariane 64", LaunchDate = new DateTime(2035, 01, 01), LaunchLocation = "Kourou, French Guiana", FlightStatus = "Scheduled", IsFeatured = false }
            );
        }
    }
}