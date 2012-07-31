using System.Threading;
using NUnit.Framework;
using Operations;

namespace AOPSample
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void When_the_operation_is_successful()
        {
            var operationClass = new OperationClass();
            var request = new OperationRequest{ Data = "incomingData" };
            var response = operationClass.SucceedingOperation(request);

        }

        [Test]
        public void When_the_operation_throws_an_exception()
        {
            var operationClass = new OperationClass();
            var request = new OperationRequest { Data = "incomingData" };
            var response = operationClass.FailingOperation(request);
        }

        [Test]
        public void When_the_operation_logging_is_asynchronous()
        {
            var operationClass = new OperationClass();
            var request = new OperationRequest { Data = "incomingData" };
            operationClass.AsyncLogged(request);
            Thread.Sleep(5000);
        }

        [Test]
        public void When_the_operation_logging_is_synchronous()
        {
            var operationClass = new OperationClass();
            var request = new OperationRequest { Data = "incomingData" };
            operationClass.SyncLogged(request);
        }
    }
}
