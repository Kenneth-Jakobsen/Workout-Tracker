using Microsoft.EntityFrameworkCore;

namespace Workout_Tracker.Models
{
    public class WorkoutsDbContext:DbContext
    {
        public DbSet<Workout> Workouts { get; set; }

        public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : base(options)
        {

        }
    }
}
