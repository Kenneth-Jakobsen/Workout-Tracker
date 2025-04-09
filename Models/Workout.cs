using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models
{
    public class Workout
    {
        [Required(ErrorMessage ="Date is required")]
        public DateOnly Date { get; set; } 

        [Required(ErrorMessage = "Type of workout is required")]
        public required string Type { get; set; } = string.Empty;

        [Required]
        [Range(1, 300, ErrorMessage = "Please enter a valid duration in minutes.")]
        public required int Duration { get; set; }

        public int Id { get; set; }
    }
}
