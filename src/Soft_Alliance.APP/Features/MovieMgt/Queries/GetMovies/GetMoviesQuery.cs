using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovies;

public class GetMoviesQuery : IRequest<List<MovieDto>>
{
    public Response<List<MovieDto>> Validate()
    {
        return new Response<List<MovieDto>>(null, true, HttpStatusCode.OK);
    }

    public QueryParamsDto Params { get; set; }
}
