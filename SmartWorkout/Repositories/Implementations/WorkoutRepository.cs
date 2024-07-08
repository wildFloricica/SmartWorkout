using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.DTOs;
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
            return _context.Workouts.Include(x => x.User).ToList();
        }
        public void AddWorkout(WorkoutDto workoutDto)
        {
            _context.Workouts.Add(new Workout()
            {
                Date = workoutDto.Date,
                Name = workoutDto.Name,
                UserId = workoutDto.UserId,
                
            });
            _context.SaveChanges();
        }
		public IEnumerable<Workout> GetUserWorkouts(int userId)
        {
           return _context.Workouts.Where(it=>it.UserId == userId).Include(u=>u.User).ToList();
        }

	}
}
