using Soft_Alliance.APP.Domain.Data;

namespace Soft_Alliance.APP.Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
        Movies = new MovieRepository(_context);
        Genres = new GenreRepository(_context);
    }

    public IMovieRepository Movies { get; }

    public IGenreRepository Genres { get; }

    public async ValueTask<bool> CommitAsync(CancellationToken cancellation)
    {
        return await _context.SaveChangesAsync(cancellation) > 0;
    }

    private readonly ApiDbContext _context;
}
