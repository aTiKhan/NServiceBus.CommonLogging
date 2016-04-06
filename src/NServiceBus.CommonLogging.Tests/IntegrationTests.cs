using System.Threading.Tasks;
using NServiceBus;
using NUnit.Framework;
using NsbLogManager = NServiceBus.Logging.LogManager;
using CommonLogManager = Common.Logging.LogManager;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public async Task Ensure_log_messages_are_redirected()
    {
        CommonLogManager.Adapter = new MemoryAdapter();

        NsbLogManager.Use<CommonLoggingFactory>();


        var endpointConfiguration = new EndpointConfiguration("CommonLoggingTests");
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        var endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            Assert.IsNotEmpty(LogMessageCapture.LoggingEvents);
        }
        finally
        {
            await endpoint.Stop();
        }
    }
}