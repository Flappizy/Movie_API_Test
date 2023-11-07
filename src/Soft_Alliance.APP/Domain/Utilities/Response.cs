namespace Soft_Alliance.APP.Domain.Utilities;
public class Response
{
    public bool Succeeded { get; set; }

    public bool NotSucceeded => !Succeeded;
    public HttpStatusCode Code { get; set; }
    public string Message { get; set; }
    
    public Response(bool isSuccess, HttpStatusCode code, string message = null)
    {
        Succeeded = isSuccess;
        Code = code;
        Message = message;
    }
}

public class Response<TResponse> : Response
{
    public TResponse Data { get; }

    public Response(TResponse result, bool isSuccess, HttpStatusCode code, string message = null)
        : base(isSuccess, code, message)
    {
        Data = result;
    }

    public Response(bool isSuccess, HttpStatusCode code)
        : base(isSuccess, code)
    {
    }
}