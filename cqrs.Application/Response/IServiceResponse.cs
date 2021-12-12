namespace cqrs.Application.Response
{
    public interface IServiceResponse
    {
        ResponseStatus Status { get; set; }
        string Message { get; set; }
        ErrorCodes ErrorCode { get; set; }
    }
}
