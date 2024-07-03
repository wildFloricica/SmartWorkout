using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.DTOs
{
    public class WorkoutDto
    {
        [Required(ErrorMessage = "Please supply name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please supply date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please supply user id")]
        public int UserId { get; set; } // Required foreign key property
    }
}
