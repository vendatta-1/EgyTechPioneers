using Microsoft.EntityFrameworkCore;
using Repositories.Data;

namespace API.Extensions;

internal static class MigrationExtenstion
{
    public static void ApplyMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        ApplyMigration<EducationContext>(scope);
        ApplyMigration<AuthDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        var dbContext=  scope.ServiceProvider.GetRequiredService<TDbContext>();
        var pendingMigrations = dbContext.Database.GetPendingMigrations();
        if (pendingMigrations.Any())
            dbContext.Database.Migrate();
        
    }
}