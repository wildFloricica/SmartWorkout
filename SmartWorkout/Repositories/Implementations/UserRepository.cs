using SmartWorkout.Context;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartWorkoutContext _context;

        public UserRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public UserDto GetById(int? id)
        {
            var user =  _context.Users.SingleOrDefault(u => u.Id == id);
            UserDto userDto = new UserDto();
            userDto.Exist = user != null;
            if(user != null)
            {
                userDto.Gender = user.Gender;
                userDto.FirstName = user.FirstName;
                userDto.LastName = user.LastName;
                userDto.Birthday = user.Birthday;
            }
            return userDto;
		}
        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }     
	}
}
