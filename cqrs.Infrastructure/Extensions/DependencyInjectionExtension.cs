using cqrs.Application.Interfaces;
using cqrs.Domain.Entities.UserAggregate;
using cqrs.Infrastructure.InfraServices.Logging;
using cqrs.Infrastructure.InfraServices.Notification;
using cqrs.Infrastructure.Persistence.Context;
using cqrs.Infrastructure.Persistence.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //EF REGISTRATION ------
            services.AddDbContext<CqrsDbContext>();

            //REPOSITORIES ------
            services.AddScoped<IUserRepository, UserRepository>();

            //INFRASTRUCTURE SERVICES ------
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient(typeof(ILogService<>), typeof(LogService<>));
            return services;
        }
    }
}
