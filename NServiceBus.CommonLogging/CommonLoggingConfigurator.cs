using LogManager = NServiceBus.Logging.LogManager;

namespace NServiceBus.CommonLogging
{
    /// <summary>
    /// Used to forward NServiceBus logging message through Common.Logging
    /// </summary>
    public static class CommonLoggingConfigurator
    {

        /// <summary>
        /// Configure NServiceBus logging messages to use Common.Logging
        /// </summary>
        public static void Configure()
        {
            LogManager.LoggerFactory = new LoggerFactory();
        }
    }
}