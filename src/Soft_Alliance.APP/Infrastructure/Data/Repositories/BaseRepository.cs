using Soft_Alliance.APP.Domain.Data;

namespace Soft_Alliance.APP.Infrastructure.Data.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public BaseRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    private readonly ApiDbContext _context;
}
