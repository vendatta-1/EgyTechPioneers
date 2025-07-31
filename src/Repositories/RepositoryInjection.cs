using Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Data; 
using Repositories.Interfaces;
using Repository.Interceptors;

namespace Repositories;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositoryInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditSaveChangesInterceptor>();
        
        services.AddScoped<IUnitOfWork, EducationContext>();

        services.AddDbContext<EducationContext>((sp, opt) =>
        {
            var interceptor = sp.GetRequiredService<AuditSaveChangesInterceptor>();

            opt.UseSqlServer(configuration.GetConnectionString("education"))
                .AddInterceptors(interceptor);
        });

        services.AddScoped(typeof(IRepository<>), typeof(Implementations.Repository<>));
        return services;
    }
}