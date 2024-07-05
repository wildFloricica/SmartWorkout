using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage :ComponentBase
    {
        [Inject]
        public IExerciseLogRepository exerciseLogRepository { get; set; }

		[Inject]
		private NavigationManager Navigation { get; set; }
		public ICollection<ExerciseLog> exerciseLogs { get; set; }
        protected override void OnInitialized()
        {
          exerciseLogs =  exerciseLogRepository.GetExerciseLogs();
        }

		private void EditExerciseLog(EditCommandContext<ExerciseLog> context)
		{
			var id = context.Item.Id;

			if (context != null && context.Item != null)
			{
				Navigation.NavigateTo($"/exercise-log/edit/{id}");
			}
		}

	}
}
