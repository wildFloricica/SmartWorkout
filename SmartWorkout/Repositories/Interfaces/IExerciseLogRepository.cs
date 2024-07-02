using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseLogRepository
    {
        ICollection<ExerciseLog> GetExerciseLogs();
        void AddExerciseLog(ExerciseLog exerciseLog);
    }
}
