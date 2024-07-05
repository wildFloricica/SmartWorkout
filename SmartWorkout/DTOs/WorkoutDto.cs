using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.DTOs
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please supply name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please supply date")]
        public DateTime Date { get; set; }
    }
}
