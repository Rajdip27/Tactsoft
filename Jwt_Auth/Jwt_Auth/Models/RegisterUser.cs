namespace Jwt_Auth.Models;

public class RegisterUser
{
	public string Name { get; set; } = "";
	public string UserName { get; set; } = "";
	public string Password { get; set; } = "";
	public string Role { get; set; } = "Everyone";
}
