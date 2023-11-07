using Soft_Alliance.APP.Domain.Enums;
using Soft_Alliance.APP.Domain.Services;

namespace Soft_Alliance.APP.Features.MovieMgt.Commands.UpdateMovie;
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager)
    {
        _unitOfWork = unitOfWork;
        _fileManager = fileManager;
    }

    public async Task<Response> HandleAsync(UpdateMovieCommand command, CancellationToken cancellationToken = default)
    {
        var movie = await _unitOfWork.Movies.GetMovieByIdAsync(command.MovieId, cancellationToken);
        if (movie is null)
            return new Response(false, HttpStatusCode.NotFound, $"Movie with this id-{command.MovieId} does not exist");

        var (photoData, photoFormat) = await _fileManager.GetFileByteDataAsync(command.Photo, FileSize.MB);
        if (photoData is null)
            return new Response(false, HttpStatusCode.BadRequest, "Invalid File size, please upload a photo not more than 1mb in size");

        var genres = await _unitOfWork.Genres.GetListOfGenresByName(command.Genres, cancellationToken);
        if (genres is null)
        {
            genres = new List<Genre>();
            foreach (var genre in command.Genres)
            {
                genres.Add(Genre.Create(genre));
            }
        }
        else
        {
            foreach (var genre in command.Genres)
            {
                var genreAlreadyExists = genres.Where(g => g.Name.ToLower() == genre.ToLower()).Any();
                if (!genreAlreadyExists)
                    genres.Add(Genre.Create(genre));
            }
        }

        movie.UpdateMovie(command.Name, command.Description, command.RealeasedDate, command.Rating, command.TicketPrice,
            command.Country, genres, photoData, photoFormat);

        var isDbOperationSuccess = await _unitOfWork.CommitAsync(cancellationToken);
        if (!isDbOperationSuccess)
            return new Response(true, HttpStatusCode.InternalServerError, "Database error");

        return new Response(true, HttpStatusCode.OK, "Movie update successful");
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileManager _fileManager;
}
