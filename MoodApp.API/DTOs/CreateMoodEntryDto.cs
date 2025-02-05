using MoodApp.DAL.Entities;

namespace MoodApp.API.DTOs
{
    public class CreateMoodEntryDto
    {
        public MoodType MoodType { get; set; }
        public string? Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
} 