using Entities.Models.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Seeds;

public static class UserSeed
{
    public static void UserCreate(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        var existingUser = userManager.FindByEmailAsync("Admin@admin.com").GetAwaiter().GetResult();
        if (existingUser == null)
        {
            var user = CreateUser();
            var result = userManager.CreateAsync(user, "Admin@2000").GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                throw new Exception(
                    $"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

        }

        var adminUser = userManager.FindByEmailAsync("Admin@admin.com").Result;
        if (!userManager.GetRolesAsync(adminUser).Result
            .Any(x => x.Equals("Admin", StringComparison.InvariantCultureIgnoreCase)))
        {
            userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
        }
    }

    private static AppUser CreateUser()
    {
        return new AppUser
        {
            Id = Guid.NewGuid(),
            FirstName = "Admin",
            LastName = "Admin",
            Email = "Admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            UserName = "Admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D")
        };
    }
}