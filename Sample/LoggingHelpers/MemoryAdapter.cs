using System;
using Common.Logging;

namespace Sample
{
    public class MemoryAdapter : ILoggerFactoryAdapter
    {
        public ILog GetLogger(Type type)
        {
            return new MemoryLog();
        }

        public ILog GetLogger(string name)
        {
            return new MemoryLog();
        }
    }
}