using Serilog;
using Tests.Tools.Logger.interfaces;

namespace Tests.Tools.Logger
{
    public class UiLogger : ILog
    {
        private readonly ILogger logger;

        public UiLogger()
        {
            logger = new LoggerConfiguration()
                .WriteTo.File("ui_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Log(string message)
        {
            logger.Information("[UI] {Message}", message);
        }
    }
}