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

        [Parameter]
        public int UserId { get; set; }
        [Inject]
        public IWorkoutRepository workoutRepository { get; set; }
        [Inject]
        private NavigationManager Navigation { get; set; }

		protected override void OnParametersSet()
		{
            workoutDto.UserId = UserId;
		}
		[SupplyParameterFromForm]
        public WorkoutDto workoutDto { get; set; } = new WorkoutDto();
        public Workout Workout { get; set; } = new Workout();
        public async Task SaveWorkout() { 
            workoutRepository.AddWorkout(workoutDto);
            await InvokeAsync(() => Navigation.NavigateTo("/workouts"));
        }
    }

}
