using System;
using System.Threading;

//[assembly: Monitoring.LoggingAspect(AttributeTargetMembers = "*Operation")]
namespace Operations
{

    public interface ISomeService
    {
        string ServiceOperation(string inputParam);
    }

    public class SomeService : ISomeService
    {
        //[Monitoring.LoggingAspect]
        public string ServiceOperation(string inputParam)
        {
            var original = inputParam.ToCharArray();
            Array.Reverse(original);

            Thread.Sleep(3000);
            return new string(original);
        }
    }

    public class SomeAsyncService : ISomeService
    {
        //[Monitoring.LoggingAspect(Async = true)]
        public string ServiceOperation(string inputParam)
        {
            var original = inputParam.ToCharArray();
            Array.Reverse(original);

            Thread.Sleep(3000);
            return new string(original);
        }
    }
}
