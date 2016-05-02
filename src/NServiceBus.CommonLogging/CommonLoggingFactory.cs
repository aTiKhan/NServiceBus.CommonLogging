namespace NServiceBus
{
    using Logging;
    using Logging.CommonLogging;

    /// <summary>
    /// Configure NServiceBus logging messages to use CommonLogging. Use by calling <see cref="LogManager.Use{T}"/> the T is <see cref="CommonLoggingFactory"/>.
    /// </summary>
    public class CommonLoggingFactory : LoggingFactoryDefinition
    {
        /// <summary>
        /// <see cref="LoggingFactoryDefinition.GetLoggingFactory"/>.
        /// </summary>
        protected override ILoggerFactory GetLoggingFactory()
        {
            return new LoggerFactory();
        }
    }
}