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


        [SupplyParameterFromForm]
        public UserDto userDto { get; set; } = new UserDto();
        public User User { get; set; } = new User();
        public async Task SaveUser()
        {
            User.FirstName = userDto.FirstName;
            User.LastName = userDto.LastName;
            User.Birthday = userDto.Birthday;
            User.Gender = userDto.Gender;
            userRepository.AddUser(User);
            await InvokeAsync(() => Navigation.NavigateTo("/UsersPage"));
        }
    }

}
