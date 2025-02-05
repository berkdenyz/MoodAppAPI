using MoodApp.DAL.Entities;

namespace MoodApp.API.DTOs
{
    public class MoodEntryDto
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public MoodType MoodType { get; set; }
        public string? Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 