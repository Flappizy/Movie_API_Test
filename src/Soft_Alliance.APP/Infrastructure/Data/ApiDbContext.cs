using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Soft_Alliance.APP.Domain.Models;

namespace Soft_Alliance.APP.Infrastructure.Data;
public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> o) : base(o)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
}
