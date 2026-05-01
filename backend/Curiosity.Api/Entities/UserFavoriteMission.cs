namespace Curiosity.Api.Entities
{
    public class UserFavoriteMission
    {
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public int MissionId { get; set; }
        public Mission? Mission { get; set; }

        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
    }
}