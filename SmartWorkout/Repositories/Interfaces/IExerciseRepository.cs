using SmartWorkout.DTOs;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        ICollection<Exercise> GetExercises();
		void AddExercise(ExerciseDto exerciseDto);
		ExerciseDto GetById(int? id);
		public void EditExercise(ExerciseDto exerciseDto);

		public void DeleteExercise(int? id);
	}
}
