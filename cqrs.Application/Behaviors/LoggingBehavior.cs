using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cqrs.Application.Interfaces;
using MediatR;

namespace cqrs.Application.Behaivors
{
    public class LoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes>
    {
        private readonly ILogService<LoggingBehavior<TReq, TRes>> _logService;

        public LoggingBehavior(ILogService<LoggingBehavior<TReq, TRes>> logService)
        {
            this._logService = logService;
        }
        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            this._logService.LogInformation($"Request was triggered : {typeof(TReq).FullName}");
            var response = await next();
            this._logService.LogInformation($"Response was created : {typeof(TRes).FullName}");
            return response;
        }
    }
}
