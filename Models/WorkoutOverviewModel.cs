namespace Workout_Tracker.Models
{
    public class WorkoutOverviewModel
    {
        public int WorkoutCount { get; set; }
        public List<Workout>? Workouts { get; set; }
        public List<int>? WorkoutDays { get; set; }
        public List<int>? WorkoutDurations { get; set; }
        public int DaysInCurrentMonth {  get; set; }
    }
}
