using Microsoft.AspNetCore.Identity;

namespace MoodApp.API.Models;

public class User : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }

    public ICollection<MoodEntry> MoodEntries { get; set; } = new List<MoodEntry>();
} 