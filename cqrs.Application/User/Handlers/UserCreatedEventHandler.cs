using cqrs.Application.Interfaces;
using cqrs.Domain.Entities.UserAggregate;
using MediatR;

namespace cqrs.Application.User.Handlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IEmailService _mailGunService;        
        private readonly ILogService<UserCreatedEventHandler> _logger;

        public UserCreatedEventHandler(IEmailService mailGunService, ILogService<UserCreatedEventHandler> logger)
        {
            _mailGunService = mailGunService;           
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            await SendActivationCodeEmailAsync(notification.CreatedUser, "Welcome!");
        }

        private async Task SendActivationCodeEmailAsync(Domain.Entities.UserAggregate.User registeredUser, string emailTitle)
        {
            this._logger.LogInformation($"UserCreatedEvent was handled.");
            this._logger.LogInformation($"Activation Email was sent to {registeredUser.Id.ToString()}.");

            //... operations...for instance use mailGunService functions...
        }
    }
}
