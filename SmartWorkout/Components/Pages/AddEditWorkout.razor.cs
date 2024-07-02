using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
    public partial class AddEditWorkout : ComponentBase
    {

        [Inject]
        public IWorkoutRepository workoutRepository { get; set; }

        [SupplyParameterFromForm]
        public Workout Workout { get; set; } = new Workout();
        public void SaveWorkout() { 
            workoutRepository.AddWorkout(Workout);
        }
    }

}
