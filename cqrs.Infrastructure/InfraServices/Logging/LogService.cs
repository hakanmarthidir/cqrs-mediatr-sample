using cqrs.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Infrastructure.InfraServices.Logging
{
    public class LogService<T> : ILogService<T>
    {
        private readonly ILogger<T> _logger;
        public LogService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(string message, params object[] args)
        {
            this._logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            this._logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            this._logger.LogWarning(message, args);
        }
    }
}
