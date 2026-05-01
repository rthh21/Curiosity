using Microsoft.AspNetCore.Identity;

namespace Curiosity.Api.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigare
        public ICollection<UserFavoriteMission>? FavoriteMissions { get; set; }
    }
}