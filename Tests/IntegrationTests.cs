using Common.Logging;
using NServiceBus;
using NServiceBus.CommonLogging;
using NServiceBus.Persistence;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Ensure_log_messages_are_redirected()
        {
            LogManager.Adapter = new MemoryAdapter();

            CommonLoggingConfigurator.Configure();

            var configure = Configure.With(b => b.EndpointName("NServiceBusCommonLoggingTests"));
            configure.UseSerialization<Json>();
            configure.UsePersistence<InMemory>();
            using (var bus = configure.CreateBus())
            {
                bus.Start();
                Assert.IsNotEmpty(MemoryLog.Messages);
            }
        }
    }
}
