namespace Curiosity.Api.DTOs
{
    public class LaunchDto
    {
        public int Id { get; set; }
        public DateTime LaunchDate { get; set; }
        public string RocketName { get; set; } = string.Empty;
        public string FlightStatus { get; set; } = string.Empty;
        public string? LiveStreamUrl { get; set; }
        public bool IsFeatured { get; set; } = false;

        // From Mission
        public string MissionTitle { get; set; } = string.Empty;
        public string MissionDescription { get; set; } = string.Empty;
        public string? MissionImageUrl { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public string LaunchLocation { get; set; } = string.Empty;
    }
}
