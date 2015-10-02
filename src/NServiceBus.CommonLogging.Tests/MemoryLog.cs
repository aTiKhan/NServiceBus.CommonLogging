using System;
using System.Collections.Generic;
using Common.Logging;
using Common.Logging.Factory;

public class MemoryLog : AbstractLogger 
{
    protected override void WriteInternal(LogLevel level, object message, Exception exception)
    {
        Messages.Add(message);
    }

    public static List<object> Messages = new List<object>();
    public override bool IsTraceEnabled => true;
    public override bool IsDebugEnabled => true;
    public override bool IsErrorEnabled => true;
    public override bool IsFatalEnabled => true;
    public override bool IsInfoEnabled => true;
    public override bool IsWarnEnabled => true;
}
