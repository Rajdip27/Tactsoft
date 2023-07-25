using Jwt_Auth.Business.Implementation;
using Jwt_Auth.Business.Interface;
using Jwt_Auth.DatabseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var authkey = builder.Configuration.GetValue<string>("JWT:secret");
builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "JWT Auth Sample",
		Version = "v1"
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddTransient<IAuthService, AuthService>();


builder.Services.AddAuthentication(item =>
{
	item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{

	item.RequireHttpsMetadata = true;
	item.SaveToken = true;
	item.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
		ValidateIssuer = false,
		ValidateAudience = false,
		//ValidateLifetime = true,
		//ClockSkew = TimeSpan.Zero
	};
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();




app.MapControllers();

app.Run();
