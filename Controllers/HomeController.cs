using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout_Tracker.Models;

namespace Workout_Tracker.Controllers
{
    public class HomeController(ILogger<HomeController> logger, WorkoutsDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            var firstDayOfMonth = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 1);
            var workouts = context.Workouts
                .Where(w => w.Date >= firstDayOfMonth)
                .ToList();

            ViewBag.WorkoutCount = workouts.Count;
            ViewBag.Workouts = workouts;
            var maxDuration = workouts.Any() ? workouts.Max(w => w.Duration) : 1;
            ViewBag.MaxDuration = maxDuration;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddWorkout()
        {
            return View();
        }

        public IActionResult WorkoutForm(Workout model)
        {
            context.Workouts.Add(model);
            context.SaveChanges();
            return RedirectToAction("Workouts");
        }

        public IActionResult Workouts()
        {
            var allWorkouts = context.Workouts.ToList(); 
            return View(allWorkouts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
