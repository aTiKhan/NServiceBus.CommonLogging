namespace NServiceBus
{
    using NServiceBus.Logging;
    using NServiceBusCommonLogging;

    /// <summary>
    /// Configure NServiceBus logging messages to use CommonLogging. User by calling LogManager.UseLogging&lt;CommonLogging&gt;.
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