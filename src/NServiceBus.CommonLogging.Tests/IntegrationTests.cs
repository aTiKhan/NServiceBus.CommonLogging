using NServiceBus;
using NUnit.Framework;
using NsbLogManager = NServiceBus.Logging.LogManager;
using CommonLogManager = Common.Logging.LogManager;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        CommonLogManager.Adapter = new MemoryAdapter();

        NsbLogManager.Use<CommonLoggingFactory>();


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