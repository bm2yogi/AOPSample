using System;
using PostSharp.Aspects;

namespace Monitoring
{
    [Serializable]
    public class Timer : BaseAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            base.OnSuccess(args);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }
    }
}