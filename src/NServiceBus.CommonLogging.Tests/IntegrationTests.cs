using Common.Logging;
using NServiceBus;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        LogManager.Adapter = new MemoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();


        var busConfig = new BusConfiguration();
        busConfig.EndpointName("CommonLoggingTests");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            Assert.IsNotEmpty(MemoryLog.Messages);
        }
    }
}