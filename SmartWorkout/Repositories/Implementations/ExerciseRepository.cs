using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.DTOs;
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
		public void AddExercise(ExerciseDto exerciseDto)
		{
			_context.Exercises.Add(new Exercise()
			{
				Type = exerciseDto.Type,
				Description = exerciseDto.Description
			});
			_context.SaveChanges();
		}

		public ExerciseDto GetById(int? id)
		{
			var exercise = _context.Exercises.SingleOrDefault(u => u.Id == id);
			ExerciseDto exerciseDto = new ExerciseDto();
			exerciseDto.Exist = exercise != null;
			if (exercise != null)
			{
				exerciseDto.Type = exercise.Type;
				exerciseDto.Description = exercise.Description;
			}
			return exerciseDto;
		}
		public void EditExercise(ExerciseDto exerciseDto)
		{
			var exercise = _context.Exercises.SingleOrDefault(u => u.Id == exerciseDto.Id);

			if (exercise != null)
			{
				exercise.Type = exerciseDto.Type;
				exercise.Description = exerciseDto.Description;
				_context.SaveChanges();
			}
		}
		public void DeleteExercise(int? id)
		{
			if (id != null) _context.Exercises.Where(u => u.Id == id).ExecuteDelete();
		}

	}
}
