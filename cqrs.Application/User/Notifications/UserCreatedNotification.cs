using cqrs.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Application.User.Notifications
{
    public class UserCreatedNotification : INotification
    {
        public string Email { get; set; }
    }

    public class EmailHandler : INotificationHandler<UserCreatedNotification>
    {
        private readonly IEmailService _emailService;
        public EmailHandler(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            await this._emailService.SendEmailAsync(notification.Email, "Welcome", "Thanks for Your SignUp...").ConfigureAwait(false);
        }
    }

    //you can create multi handler over UserCreatedNotification
    public class QueueHandler : INotificationHandler<UserCreatedNotification>
    {
        public QueueHandler()
        {
        }
        public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
             await Task.CompletedTask;
        }
    }


}
