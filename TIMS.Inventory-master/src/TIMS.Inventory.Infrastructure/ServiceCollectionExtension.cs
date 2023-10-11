using TIMS.Inventory.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static TIMS.Inventory.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TIMS.Inventory.SharedKernel.Interfaces;

namespace TIMS.Inventory.Infrastructure;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TIMSContext>((s, builder) =>
        {
            builder.UseSqlServer(configuration[ApplicationConstants.DefaultConnection]);
            builder.UseLoggerFactory(s.GetRequiredService<ILoggerFactory>());
            builder.LogTo(Console.WriteLine, LogLevel.Debug);
            // builder.AddInterceptors();
        });
        services.Scan(scan => scan.FromAssemblyOf<TIMSContext>()
    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
    .AsSelfWithInterfaces()
    .WithTransientLifetime());

        return services;
    }
}
