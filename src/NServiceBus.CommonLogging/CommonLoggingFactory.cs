namespace NServiceBus
{
    using Logging;
    using Logging.CommonLogging;

    /// <summary>
    /// Configure NServiceBus logging messages to use CommonLogging. Use by calling <see cref="LogManager.Use{T}"/> the T is <see cref="CommonLoggingFactory"/>.
    /// </summary>
    [ObsoleteEx(
        Message = "NServiceBus is now providing support for logging libraries through the Microsoft.Extensions.Logging abstraction. Remove the NServiceBus.CommonLogging package. Install NServiceBus.Extensions.Logging and logging provider package of choice instead.",
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
