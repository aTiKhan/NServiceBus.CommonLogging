using System;
using Common.Logging;

public class MemoryAdapter : ILoggerFactoryAdapter
{
    public ILog GetLogger(Type type)
    {
        return new LogMessageCapture();
    }

    public ILog GetLogger(string name)
    {
        return new LogMessageCapture();
    }
}
