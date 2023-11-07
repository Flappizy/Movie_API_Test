using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Infrastructure.Data.Repositories;
public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Where(m => m.Id == movieId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<MovieDto> GetMovieDtoByIdAsync(int movieId, CancellationToken cancellationToken)
    {
        return await _context.Movies.AsNoTracking()
            .Include(m => m.Genres)
            .Where(m => m.Id == movieId)
            .Select(m => new MovieDto
            {
               Name = m.Name,
               Description = m.Description,
               RealeasedDate = m.RealeasedDate,
               PhotoData = new PhotoDto { PhotoData = m.PhotoData, PhotoFormat = m.PhotoFormat },
               Country = m.Country,
               Genres = m.Genres.Select(g => g.Name).ToList(),
               Id = m.Id,
               Rating = m.Rating,
               TicketPrice = m.TicketPrice
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<MovieDto>> GetMoviesDtoAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        return await _context.Movies.AsNoTracking()
            .Include(m => m.Genres)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(m => new MovieDto
            {
                Name = m.Name,
                Description = m.Description,
                RealeasedDate = m.RealeasedDate,
                PhotoData = new PhotoDto { PhotoData = m.PhotoData, PhotoFormat = m.PhotoFormat },
                Country = m.Country,
                Genres = m.Genres.Select(g => g.Name).ToList(),
                Id = m.Id,
                Rating = m.Rating,
                TicketPrice = m.TicketPrice
            }).ToListAsync(cancellationToken);
    }

    public async Task DeleteMovieAsync(int movieId, CancellationToken cancellationToken)
    {
        await _context.Movies.Where(m => m.Id == movieId).ExecuteDeleteAsync(cancellationToken);
    }

    private readonly ApiDbContext _context;
}
