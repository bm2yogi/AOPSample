using System;
using Monitoring;

namespace Operations
{

    public interface IOperationClass
    {
        OperationResponse SucceedingOperation(OperationRequest request);
        OperationResponse FailingOperation(OperationRequest request);
    }

    public class OperationClass : IOperationClass
    {
        [Logging(Category = "CategoryOne")]
        public OperationResponse SucceedingOperation(OperationRequest request)
        {
            return new OperationResponse { Data = "outgoingData" };
        }

        [Logging(Category = "CategoryTwo")]
        public OperationResponse FailingOperation(OperationRequest request)
        {
            System.Threading.Thread.Sleep(1500);
            throw new ApplicationException("Oops. What'd I do?");
        }

        [Logging(Category = "Async")]
        public void AsyncLogged(OperationRequest request)
        {
        }

        [Logging(Category = "Sync")]
        public void SyncLogged(OperationRequest request)
        {
        }
    }

    public class OperationResponse
    {
        public string Data { get; set; }
        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class OperationRequest
    {
        public string Data { get; set; }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
