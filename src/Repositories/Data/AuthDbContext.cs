using Common.Data;
using Entities.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Repositories.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options)  : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options), IUnitOfWork
{
    
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);   
    }
}