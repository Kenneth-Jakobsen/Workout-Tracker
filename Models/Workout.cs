using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models
{
    public class Workout
    {
        [Required]
        public Days Day { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Please enter a valid duration in minutes.")]
        public required string Duration { get; set; }
    }
}
