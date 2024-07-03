using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
    public partial class AddEditWorkout : ComponentBase
    {

        [Inject]
        public IWorkoutRepository workoutRepository { get; set; }
        [Inject]
        private NavigationManager Navigation { get; set; }

        [SupplyParameterFromForm]
        public WorkoutDto workoutDto { get; set; } = new WorkoutDto();
        public Workout Workout { get; set; } = new Workout();
        public async Task SaveWorkout() { 
            Workout.UserId = workoutDto.UserId;
            Workout.Date = workoutDto.Date;
            Workout.Name = workoutDto.Name;
            workoutRepository.AddWorkout(Workout);
            await InvokeAsync(() => Navigation.NavigateTo("/workouts-page"));
        }
    }

}
