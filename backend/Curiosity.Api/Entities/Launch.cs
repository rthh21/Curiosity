namespace Curiosity.Api.Entities
{
    public class Launch
    {
        public int Id { get; set; }
        public DateTime LaunchDate { get; set; }
        public string RocketName { get; set; } = string.Empty;
        public string FlightStatus { get; set; } = "Scheduled";
        public string? LiveStreamUrl { get; set; }

        // Foreign Key
        public int MissionId { get; set; }
        public Mission? Mission { get; set; }
    }
}