using Microsoft.AspNetCore.Components;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
    public partial class AddEditExercise : ComponentBase
    {

		[Inject]
		public IExerciseRepository exerciseRepository { get; set; }
		[Inject]
		private NavigationManager Navigation { get; set; }

		[Parameter]
		public int? ExerciseId { get; set; }


		protected override void OnParametersSet()
		{
			if (ExerciseId != null)
			{
				exerciseDto = exerciseRepository.GetById(ExerciseId);
			}
		}

		[SupplyParameterFromForm]
		public ExerciseDto exerciseDto { get; set; } = new ExerciseDto();
		public Exercise Exercise { get; set; } = new Exercise();
		public async Task SaveExercise()
		{
			if (ExerciseId == null)
			{
				exerciseRepository.AddExercise(exerciseDto);
			}
			else
			{
				exerciseDto.Id = ExerciseId;
				exerciseRepository.EditExercise(exerciseDto);
			}
			await InvokeAsync(() => Navigation.NavigateTo("/exercises"));
		}

	}

}
