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
            if (NServiceBus.Configure.Instance != null)
            {
                var log = Common.Logging.LogManager.GetLogger(typeof(CommonLoggingConfigurator));
                log.Warn("You have called CommonLoggingConfigurator.Configure() after NServiceBus.Configure.With() has been called. To capture messages and errors that occur during configuration you should call CommonLoggingConfigurator.Configure() before NServiceBus.Configure.With().");
            }
        }
    }
}