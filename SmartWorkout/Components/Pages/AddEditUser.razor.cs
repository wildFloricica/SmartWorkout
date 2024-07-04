using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class AddEditUser : ComponentBase
    {

        [Inject]
        public IUserRepository userRepository { get; set; }
        [Inject]
        private NavigationManager Navigation { get; set; }

        [Parameter]
		public int? UserId { get; set; }


		protected override void OnParametersSet()
		{
			if(UserId != null)
            {
                userDto = userRepository.GetById(UserId);
            }
		}

		[SupplyParameterFromForm]
        public UserDto userDto { get; set; } = new UserDto();
        public User User { get; set; } = new User();
        public async Task SaveUser()
        {
            if (UserId == null)
            {
                userRepository.AddUser(userDto); 
            }
            else
            {
                userDto.Id = UserId;
                userRepository.EditUser(userDto);
            }
            await InvokeAsync(() => Navigation.NavigateTo("/users"));
        }
    }

}
