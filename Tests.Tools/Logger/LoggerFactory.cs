using Tests.Tools.Logger.enums;
using Tests.Tools.Logger.interfaces;

namespace Tests.Tools.Logger
{
    /// <summary>
    /// Factory class for creating logger instances based on the specified logger type
    /// Supports API and UI logging with extensibility for additional loggers
    /// </summary>
    public static class LoggerFactory
    {
        public static ILog CreateLogger(LoggerType type)
        {
            return type switch
            {
                LoggerType.Api => new ApiLogger(),
                LoggerType.UI => new UiLogger(),
                _ => new UiLogger()
            };
        }
    }
}