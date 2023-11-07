namespace Soft_Alliance.APP.Domain.Abstractions;
public interface IRequestHandler<TRequest>
{
    Task<Response> HandleAsync(TRequest command, CancellationToken cancellationToken = default);
}

public interface IRequestHandler<TRequest, TResponse>
{
    Task<Response<TResponse>> HandleAsync(TRequest query, CancellationToken cancellationToken = default);
}
