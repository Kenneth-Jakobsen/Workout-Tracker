using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout_Tracker.Controllers;
using Workout_Tracker.Models;

namespace Workout_Tracker.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkoutsDbContext context;

        public WorkoutsController(WorkoutsDbContext context)
        {
            this.context = context;
        }

        [HttpGet("heatmap")]
        public async Task<ActionResult<IEnumerable<WorkoutHeatmapDTO>>> GetWorkoutHeatmap()
        {
            var heatmapData = await context.Workouts
                .GroupBy(w => w.Date) 
                .Select(g => new WorkoutHeatmapDTO
                {
                    Date = g.Key,
                    Duration = g.Sum(w => w.Duration)
                })
                .ToListAsync();

            return Ok(heatmapData);
        }
    }
}
