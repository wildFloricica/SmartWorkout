using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SmartWorkout.Entities;

// Contains the identity and role information about the user
using System.Security.Claims;

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		// ProtectedSessionStorage for storing user session data securely in the browser.
		private readonly ProtectedSessionStorage _sessionStorage;

		// _anonymous for unautheticated user. a "claim" is a piece of information about a user or system entity.
		// ClaimsPrincipal is used to represent an anonymous (unauthenticated) user, and designed to work with claims-based identity systems
		// A ClaimsPrincipal can be composed of multiple ClaimsIdentity instances. 
		private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

		public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{
				var userStorageResult = await _sessionStorage.GetAsync<User>("User");
				var user = userStorageResult.Success ? userStorageResult.Value : null;
				if (user == null)
					return await Task.FromResult(new AuthenticationState(_anonymous));
				var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email),
					new Claim(ClaimTypes.Role, user.IsTrainer ? "Administrator" : "User")
				}, "CustomAuth"));
				return await Task.FromResult(new AuthenticationState(claimsPrincipal));
			}
			catch
			{
				return await Task.FromResult(new AuthenticationState(_anonymous));
			}
		}

		public void UpdateAuthenticationState(User user)
		{
			ClaimsPrincipal claimsPrincipal;

			if (user != null)
			{
				_sessionStorage.SetAsync("User", user);
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email),
					new Claim(ClaimTypes.Role, user.IsTrainer ? "Administrator" : "User")
				}));
			}
			else
			{
				_sessionStorage.DeleteAsync("User");
				claimsPrincipal = _anonymous;
			}
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
	}
}