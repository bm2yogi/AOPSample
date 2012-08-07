using System;
using Monitoring;

namespace Operations
{

    public interface IOperationClass
    {
        string SucceedingOperation(string request);
        OperationResponse FailingOperation(OperationRequest request);
        OperationResponse AsyncLogged(OperationRequest request);
        OperationResponse SyncLogged(OperationRequest request);
    }

    public class OperationClass : IOperationClass
    {
        [LoggingAspect(Category = "CategoryOne")]
        public string SucceedingOperation(string request)
        {
            Array.Reverse(request.ToCharArray());
            return request;
        }

        [LoggingAspect(Category = "CategoryTwo")]
        public OperationResponse FailingOperation(OperationRequest request)
        {
            System.Threading.Thread.Sleep(1500);
            throw new ApplicationException("Oops. What'd I do?");
        }

        [LoggingAspect(Category = "Async")]
        public OperationResponse AsyncLogged(OperationRequest request)
        {
            return new OperationResponse { Data = "outgoingData" };
        }

        [LoggingAspect(Category = "Sync")]
        public OperationResponse SyncLogged(OperationRequest request)
        {
            return new OperationResponse { Data = "outgoingData" };
        }
    }

    public class OperationResponse
    {
        public string Data { get; set; }
    }

    public class OperationRequest
    {
        public string Data { get; set; }
    }
}
