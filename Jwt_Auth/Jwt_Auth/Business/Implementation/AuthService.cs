using Jwt_Auth.Business.Interface;
using Jwt_Auth.DatabseContext;
using Jwt_Auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt_Auth.Business.Implementation;

public class AuthService : IAuthService
{
	private readonly ApplicationDbContext _context;
	private readonly IConfiguration _configuration;
	public AuthService(ApplicationDbContext context, IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
		DbSet=_context.Set<User>();
	}
	public DbSet<User> DbSet { get; }
	public async Task<User> Login(string email, string password)
	{
		User? user = await DbSet.FindAsync(email);
		if (user == null || BCrypt.Net.BCrypt.Verify(password,user.Password)==false)
		{
			return null;
		}
		var tokenHeader = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_configuration["JWT:secret"]);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.GivenName, user.Name),
				new Claim(ClaimTypes.Role, user.Role)

			}),
			IssuedAt = DateTime.UtcNow,
			Issuer = _configuration["JWT:secret"],
			Audience = _configuration["JWT:validAudience"],
			Expires = DateTime.UtcNow.AddDays(2),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHeader.CreateToken(tokenDescriptor);
		user.Token=tokenHeader.WriteToken(token);
		user.IsActive = true;
		return user;

	}

	public async Task<User> Register(User user)
	{
		user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
		DbSet.Add(user);
		await _context.SaveChangesAsync();
		return user;
	}
}
