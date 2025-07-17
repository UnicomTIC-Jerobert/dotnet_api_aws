using ICEDT.API.Models;

using Microsoft.EntityFrameworkCore;

namespace ICEDT.API.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<MainActivityType> MainActivityTypes { get; set; }
    }
}