using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoodApp.DAL.Entities;

namespace MoodApp.DAL.Context
{
    public class MoodAppDbContext : IdentityDbContext<AppUser>
    {
        public MoodAppDbContext(DbContextOptions<MoodAppDbContext> options) : base(options)
        {
        }

        public DbSet<MoodEntry> MoodEntries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionMoodStats> RegionMoodStats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AppUser configuration
            builder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.ProfilePictureUrl).HasMaxLength(2000);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime2");
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime2");
            });

            // MoodEntry configuration
            builder.Entity<MoodEntry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.HasOne(m => m.User)
                    .WithMany(u => u.MoodEntries)
                    .HasForeignKey(m => m.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Region configuration
            builder.Entity<Region>()
                .HasOne(r => r.ParentRegion)
                .WithMany(r => r.SubRegions)
                .HasForeignKey(r => r.ParentRegionId)
                .OnDelete(DeleteBehavior.Restrict);

            // RegionMoodStats configuration
            builder.Entity<RegionMoodStats>()
                .HasOne(s => s.Region)
                .WithMany(r => r.MoodStats)
                .HasForeignKey(s => s.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 