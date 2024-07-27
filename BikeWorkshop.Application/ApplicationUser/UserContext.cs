using BikeWorkshop.Application.BikeWorkshop;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BikeWorkshop.Application.ApplicationUser
{
	public interface IUserContext
	{
		CurrentUser GetCurrentUser();
	}

	public class UserContext : IUserContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserContext(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		public CurrentUser GetCurrentUser()
		{
			var user = _httpContextAccessor?.HttpContext?.User;
			if (user == null)
			{
				throw new InvalidOperationException("Context user is not present");
			}
			var id = user.FindFirst(l => l.Type == ClaimTypes.NameIdentifier)!.Value;
			var email = user.FindFirst(l => l.Type == ClaimTypes.Email)!.Value;
			
			return new CurrentUser(id, email);
		}
	}
}
