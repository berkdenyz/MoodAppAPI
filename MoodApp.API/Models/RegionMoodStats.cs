namespace MoodApp.API.Models;

public class RegionMoodStats
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string RegionId { get; set; }
    public MoodType MoodType { get; set; }
    public int Count { get; set; }
    public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
    
    public Region Region { get; set; }
} 