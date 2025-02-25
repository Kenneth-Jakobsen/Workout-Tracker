using Microsoft.EntityFrameworkCore;

namespace Workout_Tracker.Models
{
    public class WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : DbContext(options)
    {
        public DbSet<Workout> Workouts { get; set; }
    }
}
