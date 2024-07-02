using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
    public partial class AddEditExercise : ComponentBase
    {

        [Inject]
        public IExerciseRepository exerciseRepository { get; set; }

        [SupplyParameterFromForm]
        public Exercise Exercise { get; set; } = new Exercise();
        public void SaveExercise() { 
            exerciseRepository.AddExercise(Exercise);
        }
    }

}
