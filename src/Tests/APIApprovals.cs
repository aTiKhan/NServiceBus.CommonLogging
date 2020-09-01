using System.Reflection;
using NUnit.Framework;
using Particular.Approvals;
using PublicApiGenerator;

[TestFixture]
public class APIApprovals
{
    [Test]
    public void Approve()
    {
        var publicApi = ApiGenerator.GeneratePublicApi(Assembly.Load("NServiceBus.CommonLogging"), excludeAttributes: new[] { "System.Runtime.Versioning.TargetFrameworkAttribute" });
        Approver.Verify(publicApi);
    }
}