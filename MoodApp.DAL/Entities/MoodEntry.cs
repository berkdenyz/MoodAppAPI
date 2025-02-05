using System;

namespace MoodApp.DAL.Entities
{
    public class MoodEntry
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public MoodType MoodType { get; set; }
        public string? Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual AppUser User { get; set; }
    }
} 