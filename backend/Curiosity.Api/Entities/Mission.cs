namespace Curiosity.Api.Entities
{
    public class Mission
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PayloadDescription { get; set; } = string.Empty;
        public string? NewsArticleBody { get; set; }
        public string? ImageUrl { get; set; }

        // Foreign Key
        public int AgencyId { get; set; }
        public Agency? Agency { get; set; }

        // Navigare
        public ICollection<Launch>? Launches { get; set; }
        public ICollection<UserFavoriteMission>? FavoritedByUsers { get; set; }
    }
}