using System;
using System.Threading.Tasks;
using Common.Logging;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        LogManager.Adapter = new FactoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();

        var configuration = new EndpointConfiguration("CommonLoggingSample");
        configuration.EnableInstallers();
        configuration.UseTransport<LearningTransport>();
        var endpoint = await Endpoint.Start(configuration)
            .ConfigureAwait(false);
        await endpoint.SendLocal(new MyMessage())
            .ConfigureAwait(false);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpoint.Stop()
            .ConfigureAwait(false);
    }
}
