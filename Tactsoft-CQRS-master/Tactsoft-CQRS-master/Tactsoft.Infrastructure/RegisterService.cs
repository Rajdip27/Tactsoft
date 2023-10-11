using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tactsoft.Infrastructure.AppContext;
using static Tactsoft.Domain.Identities.IdentityModel;
using Microsoft.OpenApi.Models;

namespace Tactsoft.Infrastructure;

public static class RegisterService
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TactsoftDbContext>(option =>
        {
            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            option.LogTo(Console.WriteLine);
            option.UseSqlServer(configuration.GetConnectionString("DbConn"));
        });

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<TactsoftDbContext>().AddDefaultTokenProviders();

        services.AddHttpContextAccessor();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:validIssuer"],
                ValidAudience = configuration["JwtSettings:validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.ResolveConflictingActions(o => o.First());
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Learning Management System",
                Description = "An ASP.NET Core Web API for Learning Management System (LMS)",
                Contact = new OpenApiContact
                {
                    Name = "Tactsoft Limited",
                    Url = new Uri("http://tactsoftltd.com"),
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License, VERSION 2.0",
                    Url = new Uri("https://www.mit.edu/~amini/LICENSE.md")
                }
            });

        });


        return services;
    }
}