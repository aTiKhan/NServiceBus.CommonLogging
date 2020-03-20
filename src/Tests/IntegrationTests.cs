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

#pragma warning disable 0618
        NsbLogManager.Use<CommonLoggingFactory>();
#pragma warning restore 0618

        var endpointConfiguration = new EndpointConfiguration("CommonLoggingTests");
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UseTransport<LearningTransport>();
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        var endpoint = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        try
        {
            Assert.IsNotEmpty(LogMessageCapture.LoggingEvents);
        }
        finally
        {
            await endpoint.Stop()
                .ConfigureAwait(false);
        }
    }
}