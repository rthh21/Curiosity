namespace Curiosity.Api.DTOs
{
    public class MissionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PayloadDescription { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string AgencyName { get; set; } = string.Empty; // Trimitem doar numele, nu tot obiectul Agency
    }
}