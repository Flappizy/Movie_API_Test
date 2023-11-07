namespace Soft_Alliance.APP.Domain.Abstractions;
public interface IRequest<TResponse>
{
    Response<TResponse> Validate();
}

public interface IRequest
{
    Response Validate();
}
