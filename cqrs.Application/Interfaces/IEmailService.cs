namespace cqrs.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receiver, string subject, string content, CancellationToken token = default(CancellationToken));
    }

}
