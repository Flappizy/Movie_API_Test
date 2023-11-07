using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Soft_Alliance.APP.Infrastructure.Data;
public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
{
    public ApiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
        //var builder = WebApplication.CreateBuilder(args);

        var currentDirectory = Directory.GetCurrentDirectory();
        // Get the path to the directory that contains the other project's appsettings.json file
        var otherProjectDirectory = Path.Combine(currentDirectory, "..", "..", "src", "Soft_Alliance.API");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(otherProjectDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new ApiDbContext(optionsBuilder.Options);
    }
}
