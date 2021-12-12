namespace cqrs.Application.Response
{
    public interface IServiceResponse<T> : IServiceResponse
    {
        T Data { get; set; }
    }
}
