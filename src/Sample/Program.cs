using System;
using System.Threading.Tasks;
using Common.Logging;
using Common.Logging.Simple;
using NServiceBus;

class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();

        var endpointConfiguration = new EndpointConfiguration("CommonLoggingSample");
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        var endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            await endpoint.SendLocal(new MyMessage());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        finally
        {
            await endpoint.Stop();
        }
    }
}
