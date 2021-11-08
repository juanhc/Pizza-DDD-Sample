using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation("----- Handling command {CommandName} ({@Command})", request.GetType().Name, request);
                var response = await next();
                _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", request.GetType().Name, response);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.GetType().Name} - {ex.Message}");

                throw;
            }
        }
    }
}
