using Common.Logging;
using NServiceBus;
using NServiceBus.Persistence;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        LogManager.Adapter = new MemoryAdapter();

        NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();

        var configure = Configure.With(b =>
        {
            b.EndpointName("NServiceBusCommonLoggingTests");
            b.UseSerialization<Json>();
            b.EnableInstallers();
        });
        configure.UsePersistence<InMemory>();
        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Assert.IsNotEmpty(MemoryLog.Messages);
        }
    }
}

