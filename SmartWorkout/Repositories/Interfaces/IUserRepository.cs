using SmartWorkout.DTOs;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        void AddUser (User user);
		UserDto GetById(int? id);
        public void EditUser(User user);
	}
}
