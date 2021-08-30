using RocketMan.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace RocketMan.Infrastructure.Logging
{
    public class ApplicationLogger<T> : IApplicationLogger<T>
    {
        private readonly ILogger<T> _logger;

        public ApplicationLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
    }
}
