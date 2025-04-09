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
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            var firstDayOfMonth = new DateOnly(currentYear, currentMonth, 1);
            int daysInCurrentMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            var workouts = context.Workouts.Where(w => w.Date >= firstDayOfMonth).ToList();

            var viewModel = new WorkoutOverviewModel
            {
                WorkoutCount = workouts.Count,
                Workouts = workouts,
                WorkoutDays = workouts.Select(w => w.Date.Day).ToList(),
                WorkoutDurations = workouts.Select(w => w.Duration).ToList(),
                DaysInCurrentMonth = daysInCurrentMonth

            };

            return View(viewModel);
           
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
            if (ModelState.IsValid) 
            {
                context.Workouts.Add(model);
                context.SaveChanges();
                return RedirectToAction("Workouts");
            }

            return RedirectToAction("Workouts");
        
        }

        public IActionResult Workouts()
        {
            var allWorkouts = context.Workouts.ToList(); 
            return View(allWorkouts);
        }

        public IActionResult Delete(int id)
        {
            var workout = context.Workouts.FirstOrDefault(w => w.Id == id);
            context.Workouts.Remove(workout);
            context.SaveChanges();
            return RedirectToAction("Workouts");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
