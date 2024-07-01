using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class WorkoutsPage :ComponentBase
    {
        [Inject]
        public IWorkoutRepository workoutRepository { get; set; }

        
        public ICollection<Workout> workouts { get; set; }
        protected override void OnInitialized()
        {
          workouts =  workoutRepository.GetWorkouts();
            //foreach (var item in workouts)
            //{
            //    item.User.FirstName += " "+ item.User.LastName;
            //}
        }

    }
}
