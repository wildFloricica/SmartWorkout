using SmartWorkout.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.DTOs
{
    public class ExerciseLogDto
    {
        [Required(ErrorMessage = "Please supply reps")]
        public int Reps { get; set; }

        [Required(ErrorMessage = "Please supply duration")]
        public int Duration { get; set; }
        
        [Required(ErrorMessage = "Please supply workoutid")]
        public int WorkoutId { get; set; } // Required foreign key property
        
        [Required(ErrorMessage = "Please supply exerciseid")]
        public int ExerciseId { get; set; }
    }
}
