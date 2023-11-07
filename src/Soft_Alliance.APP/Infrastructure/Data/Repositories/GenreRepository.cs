namespace Soft_Alliance.APP.Infrastructure.Data.Repositories;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetListOfGenresByName(List<string> names, CancellationToken cancellationToken)
    {
        var namesSet = new HashSet<string>(names);
        return await _context.Genres
            .Where(g => namesSet.Contains(g.Name))
            .ToListAsync(cancellationToken);
    }

    private readonly ApiDbContext _context;
}
