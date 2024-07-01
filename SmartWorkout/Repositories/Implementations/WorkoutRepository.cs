using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SmartWorkoutContext _context;

        public WorkoutRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<Workout> GetWorkouts()
        {
            return _context.Workouts.Include(x=>x.User).ToList();
        }
    }
}
