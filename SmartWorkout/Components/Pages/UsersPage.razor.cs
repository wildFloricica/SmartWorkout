using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class UsersPage :ComponentBase
    {
        [Inject]
        public IUserRepository userRepository { get; set; }

		[Inject]
		private NavigationManager Navigation { get; set; }
		public ICollection<User> UsersList { get; set; }
        protected override void OnInitialized()
        {
          UsersList =  userRepository.GetUsers();
        }
        private void EditUser(EditCommandContext<User> context)
        {
            var id = context.Item.Id;

            if(context != null && context.Item != null)
            {
				Navigation.NavigateTo($"/user/edit/{id}");
            }
        }
        private void DeleteUser(DeleteCommandContext<User> context)
        {
            var id = context.Item.Id;

            if(context != null && context.Item != null)
            {
                userRepository.DeleteUser(id);
                Navigation.Refresh(forceReload: true);

			}
		}


	}
}
