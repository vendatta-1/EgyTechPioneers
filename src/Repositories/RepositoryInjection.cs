using Common.Data;
using Entities.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Data;
using Repositories.Interfaces;
using Repository.Interceptors;

namespace Repositories;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositoryInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditSaveChangesInterceptor>();

        services.AddScoped<IUnitOfWork, EducationContext>();

        services.AddDbContext<EducationContext>((sp, opt) =>
        {
            var interceptor = sp.GetRequiredService<AuditSaveChangesInterceptor>();

            opt.UseSqlServer(configuration.GetConnectionString("education"))
                .AddInterceptors(interceptor);
        });

        services.AddDbContext<AuthDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("education"));
        });
        services.AddDataProtection();

        services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.SignIn.RequireConfirmedEmail = false; //for test 
                opt.Lockout.MaxFailedAccessAttempts = 5;
                
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);//for test
            }).AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped(typeof(IRepository<>), typeof(Implementations.Repository<>));
        return services;
    }
}