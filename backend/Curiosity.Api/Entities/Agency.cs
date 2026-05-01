namespace Curiosity.Api.Entities
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }

        // Navigare
        public ICollection<Mission>? Missions { get; set; }
    }
}