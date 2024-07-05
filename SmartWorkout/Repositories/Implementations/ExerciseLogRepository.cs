using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.DTOs;
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
            return _context.ExerciseLogs.Include(x => x.Exercise).Include(x => x.Workout).ToList();
        }
        public void AddExerciseLog(ExerciseLogDto exerciseLogDto)
        {
            _context.ExerciseLogs.Add(new ExerciseLog()
            {
                ExerciseId = exerciseLogDto.ExerciseId,
                WorkoutId   = exerciseLogDto.WorkoutId,
                Reps = exerciseLogDto.Reps,
                Duration = exerciseLogDto.Duration,
                
            });
            _context.SaveChanges();
        }


		public ExerciseLogDto GetById(int id)
        {
			var exerciseLog = _context.ExerciseLogs.SingleOrDefault(u => u.Id == id);
			ExerciseLogDto exerciseLogDto = new ExerciseLogDto();
			if (exerciseLog != null)
			{
				exerciseLogDto.Id = exerciseLog.Id;
				exerciseLogDto.ExerciseId = exerciseLog.ExerciseId;
				exerciseLogDto.WorkoutId = exerciseLog.WorkoutId;
				exerciseLogDto.Reps = exerciseLog.Reps;
				exerciseLogDto.Duration = exerciseLog.Duration;
			}
			return exerciseLogDto;
		}
		public void Edit(ExerciseLogDto exerciseLogDto)
		{
			var exerciseLog = _context.ExerciseLogs.SingleOrDefault(u => u.Id == exerciseLogDto.Id);

			if (exerciseLog != null)
			{
				exerciseLog.Reps = exerciseLogDto.Reps;
				exerciseLog.Duration = exerciseLogDto.Duration;
				_context.SaveChanges();
			}
		}

	

		
	}
}
