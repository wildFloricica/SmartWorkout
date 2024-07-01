using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class ExerciseLogRepository : IExerciseLogRepository
    {
        private readonly SmartWorkoutContext _context;

        public ExerciseLogRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<ExerciseLog> GetExerciseLogs()
        {
            return _context.ExerciseLogs.Include(x=>x.Exercise).Include(x=>x.Workout).ToList();
        }
    }
}
