using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovies;
public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MovieDto>>
{
    public GetMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<List<MovieDto>>> HandleAsync(GetMoviesQuery query, CancellationToken cancellationToken = default)
    {
        var movies = await _unitOfWork.Movies.GetMoviesDtoAsync(query.Params.PageSize, query.Params.PageNumber, cancellationToken);
        return new Response<List<MovieDto>>(movies, true, HttpStatusCode.OK);
    }

    private readonly IUnitOfWork _unitOfWork;
}
