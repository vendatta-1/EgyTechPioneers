using Common.Services.Implementations;
using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class CommonInjection
{
    public static IServiceCollection AddCommonInjection(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}