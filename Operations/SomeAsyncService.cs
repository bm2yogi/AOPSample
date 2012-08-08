using System.Threading;
using Extensions;

namespace Operations
{
    public class SomeAsyncService : ISomeService
    {
        //
        //[Monitoring.LoggingAspect(Async = true)]
        public string ServiceOperation(string inputParam)
        {
            Thread.Sleep(3000);
            return inputParam.Reverse();
        }
    }
}