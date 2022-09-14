using Microsoft.Extensions.DependencyInjection;

namespace TGS.Core.Infrastructures.WebApiServices;

public static class ServiceExtensions
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IRequestAnalyzer, RequestAnalyzer>();
        _ = services.AddScoped<ILocalIpFinder, LocalIpFinder>();

        return services;
    }
}
