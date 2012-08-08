using System.Threading;
using Extensions;

namespace Operations
{
    //[Monitoring.LoggingAspect]
    public class SomeService : ISomeService
    {
        //
        //[Monitoring.LoggingAspect]
        public string ServiceOperation(string inputParam)
        {
            Thread.Sleep(3000);
            return inputParam.Reverse();
        }
    }
}