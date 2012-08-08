using System.Threading;

namespace Operations
{
    //
    //[Monitoring.LoggingAspect(AttributePriority = 0)]
    //[Monitoring.LoggingAspect(AttributeExclude = true, AttributeTargetMembers = @"regex:\.ctor", AttributePriority = 1)]
    public class AMoreComplexService : ISomeService
    {
        private readonly ISomeService _dependentService;
        public AMoreComplexService()
        {
            _dependentService = new SomeService();
        }
        public string ServiceOperation(string inputParam)
        {
            DoSomethingInternal(inputParam);
            CallSomethingExternal(inputParam);
            return "Done!";
        }

        private void DoSomethingInternal(string inputParam)
        {
            //Churn on some code
            Thread.Sleep(500);
        }

        private void CallSomethingExternal(string inputParam)
        {
            //Call on a dependency
            _dependentService.ServiceOperation(inputParam);
        }
    }
}