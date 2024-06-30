using System.Reflection.Metadata;

namespace SmartWorkout.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; } // Required foreign key property
        public User User { get; set; } = null!;

        public ICollection<ExerciseLog> ExerciseLogs { get; } = new List<ExerciseLog>();
    }
}
