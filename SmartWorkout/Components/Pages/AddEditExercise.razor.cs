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

        [SupplyParameterFromForm]
        public ExerciseDto exerciseDto { get; set; } = new ExerciseDto();
        public Exercise Exercise { get; set; } = new Exercise();
        public async Task SaveExercise() { 
            Exercise.Description = exerciseDto.Description;
            Exercise.Type = exerciseDto.Type;
            exerciseRepository.AddExercise(Exercise);
            await InvokeAsync(() => Navigation.NavigateTo("/exercises"));
        }
    }

}
