using Logic.Implementations.Helpers;
using Logic.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class LogiInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IFileService, FileService>();
        
        
        return services;
    }
    
}