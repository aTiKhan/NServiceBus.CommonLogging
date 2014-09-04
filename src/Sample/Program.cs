using System;
using System.Diagnostics;
using Common.Logging;
using NServiceBus;

class Program
{
    static void Main()
    {
        LogManager.Adapter = new MemoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();


        var busConfig = new BusConfiguration();
        busConfig.EndpointName("CommonLoggingSample");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            Trace.WriteLine(MemoryLog.Messages);
            Console.ReadLine();
        }
    }
}
