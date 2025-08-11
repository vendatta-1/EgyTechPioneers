using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repositories.Data;

namespace Repositories.Factories
{
    public class EducationContextFactory : IDesignTimeDbContextFactory<EducationContext>
    {
        public EducationContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("education");

            var optionsBuilder = new DbContextOptionsBuilder<EducationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EducationContext(optionsBuilder.Options);
        }
    }
}