using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MoodApp.DAL.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoodAppDbContext>
    {
        public MoodAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MoodAppDbContext>();
            var connectionString = "Server=BERK\\SQLEXPRESS;Database=MoodAppDb2;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);

            return new MoodAppDbContext(builder.Options);
        }
    }
} 