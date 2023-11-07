using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovie;
public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
{
    public GetMovieQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<MovieDto>> HandleAsync(GetMovieQuery query, CancellationToken cancellationToken = default)
    {
        var movie = await _unitOfWork.Movies.GetMovieDtoByIdAsync(query.MovieId, cancellationToken);
        return new Response<MovieDto>(movie, true, HttpStatusCode.OK);
    }

    private readonly IUnitOfWork _unitOfWork;
}
