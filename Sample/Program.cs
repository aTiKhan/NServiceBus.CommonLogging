using System;
using System.Diagnostics;
using Common.Logging;
using NServiceBus;
using NServiceBus.Persistence;

class Program
{
    static void Main()
    {
        LogManager.Adapter = new MemoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();

        var configure = Configure.With(b =>
        {
            b.EndpointName("NServiceBusCommonLoggingSample");
            b.UseSerialization<Json>();
            b.EnableInstallers();
            b.UseTransport<Msmq>();
            b.UsePersistence<InMemory>();
        });
        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Trace.WriteLine(MemoryLog.Messages);
            Console.ReadLine();
        }
    }
}
