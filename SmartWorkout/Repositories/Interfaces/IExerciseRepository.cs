﻿using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        ICollection<Exercise> GetExercises();
    }
}
