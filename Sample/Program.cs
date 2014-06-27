using System;
using System.Diagnostics;
using Common.Logging;
using NServiceBus;
using NServiceBus.CommonLogging;
using NServiceBus.Persistence;

class Program
{
    static void Main()
    {
        LogManager.Adapter = new MemoryAdapter();

        CommonLoggingConfigurator.Configure();

        var configure = Configure.With(b => b.EndpointName("NServiceBusCommonLoggingSample"));
        configure.UseSerialization<Json>();
        configure.UseTransport<Msmq>();
        configure.UsePersistence<InMemory>();
        configure.EnableInstallers();
        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Trace.WriteLine(MemoryLog.Messages);
            Console.ReadLine();
        }
    }
}
