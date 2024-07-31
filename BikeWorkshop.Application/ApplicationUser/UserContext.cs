using BikeWorkshop.Application.BikeWorkshop;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BikeWorkshop.Application.ApplicationUser
{
	public interface IUserContext
	{
		CurrentUser? GetCurrentUser();
	}

	public class UserContext : IUserContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserContext(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		public CurrentUser? GetCurrentUser()
		{
			var user = _httpContextAccessor?.HttpContext?.User;
			if (user == null)
			{
				throw new InvalidOperationException("Context user is not present");
			}
			if(user.Identities == null || !user.Identity.IsAuthenticated)
			{
				return null;
			}

			var id = user.FindFirst(l => l.Type == ClaimTypes.NameIdentifier)!.Value;
			var email = user.FindFirst(l => l.Type == ClaimTypes.Email)!.Value;
			var roles = user.Claims.Where(l => l.Type == ClaimTypes.Role).Select(l => l.Value); //user have many roles
			
			return new CurrentUser(id, email, roles);
		}
	}
}
