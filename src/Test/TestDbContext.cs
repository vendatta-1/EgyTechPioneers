using Microsoft.EntityFrameworkCore;

namespace Test;

public class TestDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=TestDb;username=sa;password=abdo;trustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasQueryFilter(x => x.IsActive == true);
    }
    public DbSet<Student> Students { get; set; } = null!;
}