namespace MoodApp.DAL.Entities
{
    public class RegionMoodStats
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public MoodType MoodType { get; set; }
        public int Count { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public virtual Region Region { get; set; }
    }
} 