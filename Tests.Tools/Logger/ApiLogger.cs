using Serilog;
using Tests.Tools.Logger.interfaces;

namespace Tests.Tools.Logger
{
    public class ApiLogger : ILog
    {
        private readonly ILogger logger;

        public ApiLogger()
        {
            logger = new LoggerConfiguration()
                .WriteTo.File("api_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Log(string message)
        {
            logger.Information("[API] {Message}", message);
        }
    }
}