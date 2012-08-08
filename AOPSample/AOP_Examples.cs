using NUnit.Framework;
using Operations;

namespace AOPSample
{
    [TestFixture]
    public class AOP_Examples
    {
        [Test]
        public void Monitoring_an_operation()
        {
            new SomeService().ServiceOperation("Seattle");
        }

        [Test]
        public void Monitoring_an_operation_asynchronously()
        {
            new SomeAsyncService().ServiceOperation("Seattle");
        }

        [Test]
        public void Monitoring_the_call_stack()
        {
            new AMoreComplexService().ServiceOperation("Seattle");
        }
    }
}
