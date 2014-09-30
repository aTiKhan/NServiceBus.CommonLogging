using System;
using Common.Logging;
using Common.Logging.Simple;
using NServiceBus;

class Program
{
    static void Main()
    {
        LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();

        var busConfig = new BusConfiguration();
        busConfig.EndpointName("CommonLoggingSample");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            bus.SendLocal(new MyMessage());
            Console.ReadLine();
        }
    }
}
