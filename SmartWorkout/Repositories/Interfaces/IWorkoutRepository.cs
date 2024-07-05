using SmartWorkout.DTOs;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        ICollection<Workout> GetWorkouts();
        void AddWorkout(WorkoutDto workoutDto);
        
    }
}
