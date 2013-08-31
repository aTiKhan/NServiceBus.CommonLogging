using System;
using System.Diagnostics;
using Common.Logging;
using NServiceBus;
using NServiceBus.CommonLogging;
using NServiceBus.Installation.Environments;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            Configure.GetEndpointNameAction = () => "NServiceBusCommonLoggingSample";
            LogManager.Adapter = new MemoryAdapter();

            CommonLoggingConfigurator.Configure();

            Configure.Serialization.Json();

            Configure.With()
                .DefaultBuilder()
                .UseTransport<Msmq>()
                .UnicastBus()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
            
            Debug.WriteLine(MemoryLog.Messages);

            Console.ReadLine();

        }
    }
}
