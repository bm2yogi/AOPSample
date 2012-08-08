//
[assembly: Monitoring.LoggingAspect(AttributePriority = 0, AttributeTargetTypes = "Operations.*")]
[assembly: Monitoring.LoggingAspect(AttributeExclude = true, AttributeTargetMembers = @"regex:\.ctor|\.cctor", AttributePriority = 1)]
namespace Operations
{
    public interface ISomeService
    {
        string ServiceOperation(string inputParam);
    }
}
