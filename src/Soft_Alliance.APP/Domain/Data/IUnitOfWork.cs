namespace Soft_Alliance.APP.Domain.Data;

public interface IUnitOfWork
{
    public IMovieRepository Movies { get; }
    public IGenreRepository Genres { get; }
    ValueTask<bool> CommitAsync(CancellationToken cancellation);
}
