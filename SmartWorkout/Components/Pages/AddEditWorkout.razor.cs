using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
		public IUserRepository userRepository { get; set; }

		[Inject]
		private NavigationManager Navigation { get; set; }

		public UserDto userDto { get; set; } = new UserDto();
		protected override void OnParametersSet()
		{
			workoutDto.UserId = UserId;
			userDto = userRepository.GetById(UserId);
		}


		[SupplyParameterFromForm]
		public WorkoutDto workoutDto { get; set; } = new WorkoutDto();
		public Workout Workout { get; set; } = new Workout();
		public async Task SaveWorkout()
		{
			workoutRepository.AddWorkout(workoutDto);
			await InvokeAsync(() => Navigation.NavigateTo("/workouts"));
		}
	}

}
