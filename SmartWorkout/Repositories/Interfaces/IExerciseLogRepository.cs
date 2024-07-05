using SmartWorkout.DTOs;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseLogRepository
    {
        ICollection<ExerciseLog> GetExerciseLogs();
        void AddExerciseLog(ExerciseLogDto exerciseLogDto);
        ExerciseLogDto GetById(int id);
        void Edit(ExerciseLogDto exerciseLogDto);

    }
}
