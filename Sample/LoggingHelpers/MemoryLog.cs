using System;
using System.Collections.Generic;
using Common.Logging;
using Common.Logging.Factory;

namespace Sample
{
    public class MemoryLog : AbstractLogger 
    {
        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            Messages.Add(message);
        }

        public static List<object> Messages = new List<object>();
        public override bool IsTraceEnabled{get { return true; }}
        public override bool IsDebugEnabled{get { return true; }}
        public override bool IsErrorEnabled{get { return true; }}
        public override bool IsFatalEnabled{get { return true; }}
        public override bool IsInfoEnabled{get { return true; }}
        public override bool IsWarnEnabled{get { return true; }}
    }
}