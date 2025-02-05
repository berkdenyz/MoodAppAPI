using MoodApp.DAL.Entities;

namespace MoodApp.API.DTOs
{
    public class UpdateMoodEntryDto
    {
        public MoodType MoodType { get; set; }
        public string? Note { get; set; }
    }
} 