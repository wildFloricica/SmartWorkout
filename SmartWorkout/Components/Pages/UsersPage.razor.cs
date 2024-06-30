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

        
        public ICollection<User> UsersList { get; set; }
        protected override void OnInitialized()
        {
          UsersList =  userRepository.GetUsers();
        }

    }
}
