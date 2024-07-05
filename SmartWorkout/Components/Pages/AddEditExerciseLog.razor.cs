using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
	public partial class AddEditExerciseLog : ComponentBase
	{

		[Inject]
		public IExerciseLogRepository exerciseLogRepository { get; set; }
		[Inject]
		private NavigationManager Navigation { get; set; }

		[SupplyParameterFromForm]
		public ExerciseLogDto exerciseLogDto { get; set; } = new ExerciseLogDto();
		public ExerciseLog ExerciseLog { get; set; } = new ExerciseLog();
		public async Task SaveExerciseLog()
		{


			if (WorkoutId.HasValue && ExerciseId.HasValue)
			{
				// create
				exerciseLogRepository.AddExerciseLog(exerciseLogDto);
				await InvokeAsync(() => Navigation.NavigateTo($"/exercises/{WorkoutId}"));
			}
			else if(ExerciseLogId.HasValue)
			{
				// edit
				exerciseLogRepository.Edit(exerciseLogDto);
				await InvokeAsync(() => Navigation.NavigateTo($"/exercise-logs"));
			}
		


		}

		[Parameter]
		public int? WorkoutId { get; set; }
		[Parameter]
		public int? ExerciseId { get; set; }
		[Parameter]
		public int? ExerciseLogId { get; set; }
		protected override void OnParametersSet()
		{
			if (WorkoutId.HasValue)
			{
				exerciseLogDto.WorkoutId = (int)WorkoutId;
			}
			if (ExerciseId.HasValue)
			{
				exerciseLogDto.ExerciseId = (int)ExerciseId;
			}
			if(ExerciseLogId.HasValue)
			{
				exerciseLogDto.Id = (int)ExerciseLogId;
				exerciseLogDto = exerciseLogRepository.GetById((int)ExerciseLogId);
			}
		}
	}

}
