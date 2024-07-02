using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;


namespace SmartWorkout.Components.Pages
{
    public partial class AddEditExerciseLog : ComponentBase
    {

        [Inject]
        public IExerciseLogRepository exerciseLogRepository { get; set; }

        [SupplyParameterFromForm]
        public ExerciseLog ExerciseLog { get; set; } = new ExerciseLog();
        public void SaveExerciseLog() { 
            exerciseLogRepository.AddExerciseLog(ExerciseLog);
        }
    }

}
