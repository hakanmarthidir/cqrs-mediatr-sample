using cqrs.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Infrastructure.InfraServices.Notification
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string receiver, string subject, string content, CancellationToken token = default)
        {
            //emailing...
            return Task.CompletedTask;
        }
    }
}
