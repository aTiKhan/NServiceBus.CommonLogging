namespace NServiceBus
{
    using Logging;
    using Logging.CommonLogging;

    /// <summary>
    /// Configure NServiceBus logging messages to use CommonLogging. Use by calling <see cref="LogManager.Use{T}"/> the T is <see cref="CommonLoggingFactory"/>.
    /// </summary>
    [ObsoleteEx(
        Message = "Support for external logging providers is no longer provided by NServiceBus providers for each logging framework. Instead, the NServiceBus.Extensions.Logging library provides the ability to use any logging provider that conforms to the Microsoft.Extensions.Logging abstraction.",
        RemoveInVersion = "7.0.0",
        TreatAsErrorFromVersion = "6.0.0")]
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