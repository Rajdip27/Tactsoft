using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;
public static class AppServiceExtensions
{
    public static IApplicationBuilder UseCore(this IApplicationBuilder app)
    {
        app.UseResponseCaching();
        app.UseResponseCompression();
        // app.UseCertificateForwarding();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRouting();

        return app;
    }
}
