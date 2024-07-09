using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public ICollection<Workout> Workouts { get; } = new List<Workout>();
        [EmailAddress]
        public string? Email { get; set; }
		public Boolean IsTrainer { get; set; } = false;
    }
}

