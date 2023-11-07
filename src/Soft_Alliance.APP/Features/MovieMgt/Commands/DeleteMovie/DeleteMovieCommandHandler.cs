namespace Soft_Alliance.APP.Features.MovieMgt.Commands.DeleteMovie;
public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> HandleAsync(DeleteMovieCommand command, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Movies.DeleteMovieAsync(command.MovieId, cancellationToken);
        return new Response(true, HttpStatusCode.OK, "Successful delete");
    }

    private readonly IUnitOfWork _unitOfWork;
}
