using System.Collections.Generic;

namespace Curiosity.Api.Entities
{
    public class Rocket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double PayloadCapacity { get; set; } // in kilograms

        // Navigation
        public ICollection<Launch>? Launches { get; set; }
    }
}
