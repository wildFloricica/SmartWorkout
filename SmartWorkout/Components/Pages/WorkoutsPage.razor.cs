﻿using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;
using System.Diagnostics.Contracts;

namespace SmartWorkout.Components.Pages
{
	public partial class WorkoutsPage : ComponentBase
	{
		[Inject]
		public IWorkoutRepository workoutRepository { get; set; }
		[Inject]
		private NavigationManager Navigation { get; set; }

		public ICollection<Workout> workouts { get; set; }

		[Inject]

		private ProtectedSessionStorage _sessionStorage { get; set; }


		protected override void OnInitialized()
		{
			if (UserId == null) workouts = workoutRepository.GetWorkouts();
			//foreach (var item in workouts)
			//{
			//    item.User.FirstName += " "+ item.User.LastName;
			//}
		}


		[Parameter]
		public int? UserId { get; set; }
		protected override void OnParametersSet()
		{
			if (UserId != null) workouts = (ICollection<Workout>)workoutRepository.GetUserWorkouts((int)UserId);
		}

		public void GoToExercises(EditCommandContext<Workout> context)
		{
			var id = context.Item.Id;

			if (context != null && context.Item != null)
			{
				Navigation.NavigateTo($"/exercises/{id}");
			}
		}
	}
}
