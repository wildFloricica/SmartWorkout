using BlazorServerAuthenticationAndAuthorization.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using SmartWorkout.DTOs;
using SmartWorkout.Repositories.Interfaces;
using System.Security.Authentication;

namespace SmartWorkout.Services.Interfaces
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly IUserRepository _userRepository;

		private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;
		public AuthorizationService(IUserRepository userRepository, AuthenticationStateProvider authsp)
		{
			_userRepository = userRepository;
			_customAuthenticationStateProvider = (CustomAuthenticationStateProvider)authsp;
		}

		public static UserDto? CurrentUser { get; set; }


		public void Login(LoginDto loginDto)
		{
			var userToLogin = _userRepository.GetUserByEmail(loginDto.email);
			if (userToLogin == null)
			{
				throw new Exception("Wrong email or password");
			}

			if (loginDto.password != userToLogin.Birthday.ToString("MMyyyy"))
			{
				throw new Exception("Wrong email or password");
			}
			_customAuthenticationStateProvider.UpdateAuthenticationState(userToLogin);
		}

		public UserDto GetCurrentUser()
		{
			return CurrentUser;
		}

		public bool IsUserPresent()
		{
			if (CurrentUser == null)
			{
				return false;
			}

			return true;
		}

		public void LogOut()
		{
			CurrentUser = null;
		}
	}
}
