namespace NServiceBus.Logging.CommonLogging
{
    using System;
    using Logging;

    class LoggerFactory : ILoggerFactory
    {
        public ILog GetLogger(Type type)
        {
            return new Logger(Common.Logging.LogManager.GetLogger(type));
        }

        public ILog GetLogger(string name)
        {
            return new Logger(Common.Logging.LogManager.GetLogger(name));
        }
    }
}