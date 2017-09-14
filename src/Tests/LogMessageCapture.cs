using System;
using System.Collections.Generic;
using Common.Logging;
using Common.Logging.Factory;

public class LogMessageCapture : AbstractLogger
{
    protected override void WriteInternal(LogLevel level, object message, Exception exception)
    {
        LoggingEvents.Add(message);
    }

    public static List<object> LoggingEvents = new List<object>();
    public override bool IsTraceEnabled => true;
    public override bool IsDebugEnabled => true;
    public override bool IsErrorEnabled => true;
    public override bool IsFatalEnabled => true;
    public override bool IsInfoEnabled => true;
    public override bool IsWarnEnabled => true;
}
