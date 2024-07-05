using Blazorise.DataGrid;
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

		[Inject]
		private NavigationManager Navigation { get; set; }
		public ICollection<Exercise> ExercisesList { get; set; }
		[Parameter]
		public int? WorkoutId {  get; set; }
		protected override void OnInitialized()
		{
			ExercisesList = exerciseRepository.GetExercises();
		}
		private void EditExercise(EditCommandContext<Exercise> context)
		{
			var id = context.Item.Id;

			if (context != null && context.Item != null)
			{
				Navigation.NavigateTo($"/exercise/edit/{id}");
			}
		}
		private void DeleteExercise(DeleteCommandContext<Exercise> context)
		{
			var id = context.Item.Id;

			if (context != null && context.Item != null)
			{
				exerciseRepository.DeleteExercise(id);
				Navigation.Refresh(forceReload: true);

			}
		}

		public void CreateExerciseLog(EditCommandContext<Exercise> context)
		{
			var id = context.Item.Id;

			if (context != null && context.Item != null)
			{
				Navigation.NavigateTo($"/exercise-log/add/{WorkoutId}/{id}");
			}
		}
	}
}
