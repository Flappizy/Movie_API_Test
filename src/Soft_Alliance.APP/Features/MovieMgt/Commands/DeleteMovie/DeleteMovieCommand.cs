namespace Soft_Alliance.APP.Features.MovieMgt.Commands.DeleteMovie;
public class DeleteMovieCommand : IRequest
{
    public Response Validate()
    {
        if (MovieId <= 0)
            return new Response(false, HttpStatusCode.BadRequest, "Invalid movie Id");

        return new Response(true, HttpStatusCode.OK, "Validation Successful");
    }

    public int MovieId { get; set; }
}
