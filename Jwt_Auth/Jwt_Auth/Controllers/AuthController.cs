using Jwt_Auth.Business.Interface;
using Jwt_Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Auth.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	[AllowAnonymous]
	[HttpPost]
	public async Task<IActionResult> Login([FromBody] LoginUser user)
	{
		if (String.IsNullOrEmpty(user.UserName))
		{
			return BadRequest(new { message = "Email address needs to entered" });
		}
		else if (String.IsNullOrEmpty(user.Password))
		{
			return BadRequest(new { message = "Password needs to entered" });
		}
		User loggedInUser = await _authService.Login(user.UserName, user.Password);

		if (loggedInUser != null)
		{
			return Ok(loggedInUser);
		}
		return BadRequest(new { message = "User login unsuccessful" });
	}
	// POST: auth/register
	[AllowAnonymous]
	[HttpPost]
	public async Task<IActionResult> Register([FromBody] RegisterUser user)
	{
		if (String.IsNullOrEmpty(user.Name))
		{
			return BadRequest(new { message = "Name needs to entered" });
		}
		else if (String.IsNullOrEmpty(user.UserName))
		{
			return BadRequest(new { message = "User name needs to entered" });
		}
		else if (String.IsNullOrEmpty(user.Password))
		{
			return BadRequest(new { message = "Password needs to entered" });
		}

		User userToRegister = new(user.UserName, user.Name, user.Password, user.Role);

		User registeredUser = await _authService.Register(userToRegister);

		User loggedInUser = await _authService.Login(registeredUser.UserName, user.Password);

		if (loggedInUser != null)
		{
			return Ok(loggedInUser);
		}

		return BadRequest(new { message = "User registration unsuccessful" });
	}

}
