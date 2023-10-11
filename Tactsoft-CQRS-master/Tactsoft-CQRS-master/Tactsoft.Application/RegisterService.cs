using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tactsoft.Application.Profiles;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Application.Repository.EntityRepository;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Json.Serialization;
using Tactsoft.Application.Models.Auth;
using Tactsoft.Application.Common;
using Tactsoft.Infrastructure.Healper.Acls;
using Tactsoft.Application.AuthServices;

namespace Tactsoft.Application;

public static class RegisterService
{
    public static IServiceCollection ApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                             .RequireAuthenticatedUser()
                             .Build();
            config.Filters.Add(new AuthorizeFilter(policy));

        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });


        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ISignInHelper, SignInHelper>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();


        return services;
    }
}