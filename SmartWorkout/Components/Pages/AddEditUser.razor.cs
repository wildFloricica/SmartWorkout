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
            User.FirstName = userDto.FirstName;
            User.LastName = userDto.LastName;
            User.Birthday = userDto.Birthday;
            User.Gender = userDto.Gender;
            if (UserId == null)
            {
                userRepository.AddUser(User); 
            }
            else
            {

                // GET USER BY ID DIN BAZA
                User.Id = (int)UserId;
                userRepository.EditUser(User);
            }
            await InvokeAsync(() => Navigation.NavigateTo("/users"));
        }
    }

}
