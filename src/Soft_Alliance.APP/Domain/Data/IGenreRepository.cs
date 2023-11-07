namespace Soft_Alliance.APP.Domain.Data;
public interface IGenreRepository : IBaseRepository<Genre>
{
    Task<List<Genre>> GetListOfGenresByName(List<string> names, CancellationToken cancellationToken);
}
