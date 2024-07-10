using SmartWorkout.DTOs;

namespace SmartWorkout.Services.Interfaces
{
	public  interface IAuthorizationService
	{

		void Login(LoginDto loginDto);
		UserDto GetCurrentUser();
		bool IsUserPresent();
		void LogOut();
	}

}
