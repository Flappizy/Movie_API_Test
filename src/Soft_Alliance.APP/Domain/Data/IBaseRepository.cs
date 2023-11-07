namespace Soft_Alliance.APP.Domain.Data;

public interface IBaseRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
}
