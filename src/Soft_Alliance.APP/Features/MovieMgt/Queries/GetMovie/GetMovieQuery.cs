using Soft_Alliance.APP.Domain.Dtos;

namespace Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovie;
public class GetMovieQuery : IRequest<MovieDto>
{
    public Response<MovieDto> Validate()
    {
        if (MovieId <= 0)
            return new Response<MovieDto>(null, false, HttpStatusCode.BadRequest, "Invalid movie Id");

        return new Response<MovieDto>(null, true, HttpStatusCode.OK);
    }

    public int MovieId { get; set; }
}
