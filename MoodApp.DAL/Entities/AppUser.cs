using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MoodApp.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<MoodEntry> MoodEntries { get; set; }

        public AppUser()
        {
            MoodEntries = new List<MoodEntry>();
        }
    }
} 