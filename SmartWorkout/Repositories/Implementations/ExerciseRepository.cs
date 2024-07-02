using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly SmartWorkoutContext _context;

        public ExerciseRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }
        public void AddExercise(Exercise exercise)
        {
            _context.Add(exercise);
            _context.SaveChanges();
        }

    }
}
