namespace MoodApp.API.Models;

public class Region
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double LatitudeDelta { get; set; }
    public double LongitudeDelta { get; set; }
    public string? ParentRegionId { get; set; }
    
    public Region? ParentRegion { get; set; }
    public ICollection<Region> ChildRegions { get; set; }
    public ICollection<MoodEntry> MoodEntries { get; set; }
    public ICollection<RegionMoodStats> MoodStats { get; set; }
} 