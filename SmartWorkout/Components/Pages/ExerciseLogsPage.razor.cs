using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage :ComponentBase
    {
        [Inject]
        public IExerciseLogRepository exerciseLogRepository { get; set; }

        
        public ICollection<ExerciseLog> exerciseLogs { get; set; }
        protected override void OnInitialized()
        {
          exerciseLogs =  exerciseLogRepository.GetExerciseLogs();
        }

    }
}
