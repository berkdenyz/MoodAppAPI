using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoodApp.API.Models;

namespace MoodApp.API.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<MoodEntry> MoodEntries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<RegionMoodStats> RegionMoodStats { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        // MoodEntry
        modelBuilder.Entity<MoodEntry>()
            .HasOne(m => m.User)
            .WithMany(u => u.MoodEntries)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Region
        modelBuilder.Entity<Region>()
            .HasOne(r => r.ParentRegion)
            .WithMany(r => r.ChildRegions)
            .HasForeignKey(r => r.ParentRegionId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // RegionMoodStats
        modelBuilder.Entity<RegionMoodStats>()
            .HasOne(s => s.Region)
            .WithMany(r => r.MoodStats)
            .HasForeignKey(s => s.RegionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 