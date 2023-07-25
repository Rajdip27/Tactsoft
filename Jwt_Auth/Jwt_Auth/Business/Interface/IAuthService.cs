using Jwt_Auth.Models;

namespace Jwt_Auth.Business.Interface;

public interface IAuthService
{
	public Task<User> Login(string email, string password);
	public Task<User> Register(User user);
}
