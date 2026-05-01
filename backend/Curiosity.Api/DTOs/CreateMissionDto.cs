namespace Curiosity.Api.DTOs
{
    public class CreateMissionDto
    {
        public string Title { get; set; } = string.Empty;
        public string PayloadDescription { get; set; } = string.Empty;
        public string? NewsArticleBody { get; set; }
        public int AgencyId { get; set; }
    }
}