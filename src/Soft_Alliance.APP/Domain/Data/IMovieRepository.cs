using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Domain.Data;
public interface IMovieRepository : IBaseRepository<Movie>
{
    Task DeleteMovieAsync(int movieId, CancellationToken cancellationToken);
    Task<Movie> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken);
    Task<MovieDto> GetMovieDtoByIdAsync(int movieId, CancellationToken cancellationToken);
    Task<List<MovieDto>> GetMoviesDtoAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
}
