using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TIMS.Inventory.Application;
using TIMS.Inventory.Infrastructure;
using TIMS.Inventory.SharedKernel.Common;
using static TIMS.Inventory.Infrastructure.Constants;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepository(configuration);
        services.AddHttpContextAccessor();
        services.AddControllers();
        services.AddOptions();
        services.AddOptions<ApplicationSettings>(ApplicationConstants.ApplicationSettings);
        services.AddApplicationServices();
        services.AddCors(s => s.AddDefaultPolicy(configurePolicy => configurePolicy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().AllowAnyOrigin()));
        services.AddResponseCaching();
        services.AddResponseCompression();
        services.AddDistributedMemoryCache();
        // services.AddCertificateForwarding(conf=>conf.CertificateHeader="");
        return services;
    }
}
