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
    }
}
