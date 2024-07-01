using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExercisesPage :ComponentBase
    {
        [Inject]
        public IExerciseRepository exerciseRepository { get; set; }

        
        public ICollection<Exercise> exercises { get; set; }
        protected override void OnInitialized()
        {
          exercises =  exerciseRepository.GetExercises();
        }

    }
}
