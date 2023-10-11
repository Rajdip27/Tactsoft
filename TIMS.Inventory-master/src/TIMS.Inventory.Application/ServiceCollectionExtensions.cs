using TIMS.Inventory.Application;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
        .AddClasses(classes => classes.AssignableTo<IApplication>())
        .AsSelfWithInterfaces()
        .WithTransientLifetime());
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(typeof(IApplication).Assembly);
        });

        services.AddAutoMapper(typeof(IApplication).Assembly);
    }
}
