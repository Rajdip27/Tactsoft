namespace Tactsoft.Application.Models.Auth;

public class LoginResponse
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}

