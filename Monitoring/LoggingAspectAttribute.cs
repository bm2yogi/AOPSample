using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Monitoring
{
    // PostSharp documentation: http://www.sharpcrafters.com/postsharp/documentation

    [Serializable]
    public sealed class LoggingAspectAttribute : OnMethodBoundaryAspect
    {
        public bool Async { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = Stopwatch.StartNew();
            Console.WriteLine("--OnEntry--{0}.{1}",args.Method.DeclaringType.Name, args.Method.Name);
            Console.WriteLine("Async={0}", Async);
            Console.WriteLine("Method ({0}) started at {1:mm:ss}.", args.Method.Name, DateTime.Now);
            Console.WriteLine("Value for parameter ({0}) was provided as \"{1}\".", args.Method.GetParameters().First().Name, args.Arguments[0]);

            if (Async)
                new TaskFactory().StartNew(() => _writeToLog(args));
            else
                _writeToLog(args);

            Console.WriteLine();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("--OnSuccess--{0}.{1}", args.Method.DeclaringType.Name, args.Method.Name);
            Console.WriteLine("Method ({0}) completed without errors at {1:mm:ss}.", args.Method.Name, DateTime.Now);
            Console.WriteLine();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("--OnException--{0}.{1}", args.Method.DeclaringType.Name, args.Method.Name);
            //args.FlowBehavior = FlowBehavior.Continue;
            Console.WriteLine("Exception observed in method ({0}) at {1:mm:ss}. Message: {2}", args.Method.Name, DateTime.Now,
                              args.Exception.Message);
            Console.WriteLine();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("--OnExit--{0}.{1}", args.Method.DeclaringType.Name, args.Method.Name);
            var stopWatch = (Stopwatch)args.MethodExecutionTag;

            Console.WriteLine("Method ({0}) exited at {1:mm:ss}.", args.Method.Name, DateTime.Now);
            Console.WriteLine("Method completed in {0} seconds.", stopWatch.ElapsedMilliseconds/1000);
            Console.WriteLine("Method returned value \"{0}\".", args.ReturnValue);
            Console.WriteLine();
        }

        private readonly Action<MethodExecutionArgs> _writeToLog =
            (args) =>
                {
                    Console.WriteLine("Logging activity ({0}) started: {1:mm:ss}.", args.Method.Name, DateTime.Now);
                    Thread.Sleep(2000);
                    Console.WriteLine("Logging activity ({0}) ended: {1:mm:ss}.", args.Method.Name, DateTime.Now);
                };
    }
}
