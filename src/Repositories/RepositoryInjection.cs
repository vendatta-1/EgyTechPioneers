using Common.Data;
using Entities.Models.Security;
using Microsoft.AspNetCore.Builder;
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

     

        services.AddDbContext<EducationContext>((sp, opt) =>
        {
            var interceptor = sp.GetRequiredService<AuditSaveChangesInterceptor>();

            opt.UseSqlServer(configuration.GetConnectionString("education"))
                .AddInterceptors(interceptor);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EducationContext>());

        services.AddDbContext<AuthDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("education"));
        });
        services.AddDataProtection();

        services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
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

    public static WebApplication RoleSeed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        List<string> roles =
        [
            "Admin",
            "Student",
            "Instructor",
            "SupportAgent",
            "User"
        ];
        foreach (var role in roles)
        {
            if (!roleManager.RoleExistsAsync(role).Result)
                roleManager.CreateAsync(new IdentityRole<Guid>(role)).Wait();
        }
       
        return app;
    }
}