﻿using SmartWorkout.DTOs;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        void AddUser (UserDto userDto);
		UserDto GetById(int? id);
        public void EditUser(UserDto userDto);
	    
        public void DeleteUser(int? id);


		public User GetUserByEmail (string email);

	}

}
