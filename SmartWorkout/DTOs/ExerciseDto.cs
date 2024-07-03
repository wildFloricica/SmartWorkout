using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.DTOs
{
    public class ExerciseDto
    {
        [Required(ErrorMessage = "Please supply description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please supply type")]
        public string Type { get; set; }
    }
}
