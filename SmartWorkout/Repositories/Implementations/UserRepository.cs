using Microsoft.EntityFrameworkCore;
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

		public void AddUser(UserDto userDto)
		{
			_context.Users.Add(new User()
			{
				Birthday = userDto.Birthday,
				Gender = userDto.Gender,
				FirstName = userDto.FirstName,
				LastName = userDto.LastName,
				Email = userDto.Email,
			});
			_context.SaveChanges();
		}

		public UserDto GetById(int? id)
		{
			var user = _context.Users.SingleOrDefault(u => u.Id == id);
			UserDto userDto = new UserDto();
			userDto.Exist = user != null;
			if (user != null)
			{
				userDto.Gender = user.Gender;
				userDto.FirstName = user.FirstName;
				userDto.LastName = user.LastName;
				userDto.Birthday = user.Birthday;
				userDto.Email = user.Email;
			}
			return userDto;
		}
		public void EditUser(UserDto userDto)
		{
			var user = _context.Users.SingleOrDefault(u => u.Id == userDto.Id);

			if (user != null)
			{
				user.FirstName = userDto.FirstName;
				user.LastName = userDto.LastName;
				user.Birthday = userDto.Birthday;
				user.Gender = userDto.Gender;
				user.Email = userDto.Email;
				_context.SaveChanges();
			}
		}
		public void DeleteUser(int? id)
		{
			if(id != null) _context.Users.Where(u => u.Id == id).ExecuteDelete();
		}



		public bool existsByEmail(string email)
		{
			User existingUser = _context.Users.FirstOrDefault(x => x.Email == email);

			if (existingUser != null)
			{
				return true;
			}
			return false;
		}

	

		public User GetUserByEmail(string email)
		{
			return _context.Users.FirstOrDefault(x => x.Email == email);
		}
	}
}
