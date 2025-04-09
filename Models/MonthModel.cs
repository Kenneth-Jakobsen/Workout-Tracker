namespace Workout_Tracker.Models
{
    public class MonthModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int DaysInCurrentMonth {  get; set; }
        public DateOnly FirstDayOffMonth { get; set; }
        public List<Workout> Workouts { get; set; }

        public MonthModel(int month, int year, List<Workout> workouts)
        {
            Month = month;
            Year = year;
            DaysInCurrentMonth = DateTime.DaysInMonth(year, month);
            FirstDayOffMonth = new DateOnly(year,month,1);
            Workouts = workouts;
        }
    }
}
