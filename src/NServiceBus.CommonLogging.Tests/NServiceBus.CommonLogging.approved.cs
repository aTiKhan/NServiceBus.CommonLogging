[assembly: System.CLSCompliantAttribute(true)]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.5.2", FrameworkDisplayName=".NET Framework 4.5.2")]

namespace NServiceBus
{
    
    public class CommonLoggingFactory : NServiceBus.Logging.LoggingFactoryDefinition
    {
        public CommonLoggingFactory() { }
        protected override NServiceBus.Logging.ILoggerFactory GetLoggingFactory() { }
    }
}