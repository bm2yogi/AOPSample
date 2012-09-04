using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace Monitoring
{
    [Serializable]
    public class CounterAttribute : BaseAspect
    {
        public CounterAttribute(string eventName)
        {
            Event = eventName;
        }

        public string Event { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var TimeStamp = DateTime.Now;

            var userEvent = new
                {
                    Event,
                    TimeStamp,
                    Module = args.Method.Module.Name,
                    Method = args.Method.Name,
                };

            EventPublisher.Publish(userEvent);
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