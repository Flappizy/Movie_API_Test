using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soft_Alliance.APP.Domain.Services;
using Soft_Alliance.APP.Infrastructure.Data;
using Soft_Alliance.APP.Infrastructure.Data.Repositories;
using Soft_Alliance.APP.Infrastructure.Services;

namespace Soft_Alliance.APP;

public static class App
{
    public static WebApplicationBuilder AddSharedServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApiDbContext>(o => o.UseSqlServer(connectionString));
        builder.Services.AddSingleton<IFileManager, FileManager>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        return builder;
    }
}
