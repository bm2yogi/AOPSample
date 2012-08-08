using System;
using PostSharp.Aspects;

namespace Monitoring
{
    [Serializable]
    public class ExceptionHandlingAspectAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
        }
    }

    [Serializable]
    public class LoggingAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
        }

        public override void OnExit(MethodExecutionArgs args)
        {
        }
    }
}