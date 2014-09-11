using System;
using Common.Logging.Simple;
using NServiceBus;
using NsbLogManager = NServiceBus.Logging.LogManager;
using CommonLogManager = Common.Logging.LogManager;

class Program
{
    static void Main()
    {
        CommonLogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

        NsbLogManager.Use<CommonLoggingFactory>();

        var busConfig = new BusConfiguration();
        busConfig.EndpointName("CommonLoggingSample");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            Console.ReadLine();
        }
    }
}
