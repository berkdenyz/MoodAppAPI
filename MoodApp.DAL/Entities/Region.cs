namespace MoodApp.DAL.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Boundaries { get; set; }
        public int? ParentRegionId { get; set; }

        public virtual Region ParentRegion { get; set; }
        public virtual ICollection<Region> SubRegions { get; set; }
        public virtual ICollection<RegionMoodStats> MoodStats { get; set; }
    }
} 