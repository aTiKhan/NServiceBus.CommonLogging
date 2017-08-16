using Common.Logging.Simple;

public class ConsoleOutLoggerFactoryAdapter : AbstractSimpleLoggerFactoryAdapter
{

    public ConsoleOutLoggerFactoryAdapter() : base(null)
    {
    }

    protected override Common.Logging.ILog CreateLogger(string name, Common.Logging.LogLevel level, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
    {
        return new ConsoleOutLogger(name, level, showLevel, showDateTime, showLogName, dateTimeFormat);
    }
}