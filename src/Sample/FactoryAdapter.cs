using Common.Logging;
using Common.Logging.Simple;

public class FactoryAdapter : AbstractSimpleLoggerFactoryAdapter
{
    public FactoryAdapter() : base(null)
    {
    }

    protected override ILog CreateLogger(string name, LogLevel level, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
    {
        return new ConsoleOutLogger(name, level, showLevel, showDateTime, showLogName, dateTimeFormat);
    }
}