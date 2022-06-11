using cqrs.Application.Interfaces;
using MediatR;
using System.Reflection;

namespace cqrs.Application.Behaivors
{  
    public class LoggingBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : IRequest<TRes>
    {
        private readonly ILogService<LoggingBehavior<TReq, TRes>> _logService;

        public LoggingBehavior(ILogService<LoggingBehavior<TReq, TRes>> logService)
        {
            this._logService = logService;
        }
        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            this._logService.LogInformation($"Request was triggered : {typeof(TReq).FullName}");
            Type requestType = request.GetType();
            var props = new List<PropertyInfo>(requestType.GetProperties());
            foreach (var prop in props)
            {
                var data = prop.GetValue(request, null);
                //if (data != null) 
                //{
                this._logService.LogInformation($"{prop.Name} - {data}");
                //}
            }
            var response = await next();
            this._logService.LogInformation($"Response was created : {typeof(TRes).FullName}");
            return response;
        }
    }
}
