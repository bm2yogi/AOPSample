using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Monitoring
{
    // PostSharp documentation: http://www.sharpcrafters.com/postsharp/documentation

    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class LoggingAspectAttribute : OnMethodBoundaryAspect
    {
        public string Category { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Method started: {0:ss.ffff}", DateTime.Now);
            Console.WriteLine("Value for parameter ({0}) was provided as {1}", args.Method.GetParameters().First().Name, args.Arguments[0]);

            if (Category == "Async")
                new TaskFactory().StartNew(
                    () =>
                    {
                        Console.WriteLine("Logging activity ({0}) started: {1:ss.ffff}", args.Method.Name, DateTime.Now);
                        Thread.Sleep(3000);
                        Console.WriteLine("Logging activity ({0}) ended: {1:ss.ffff}",args.Method.Name, DateTime.Now);
                    }

                    );

            else if (Category == "Sync")
            {
                Console.WriteLine("Logging activity started: {0:ss.ffff}", DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("Logging activity ended: {0:ss.ffff}", DateTime.Now);
            }

            else
            {
                Console.WriteLine("Entered Method {0} at {1:HH:mm:ss.ffff} with arguments: {2}", args.Method.Name,
                                  DateTime.Now, args.Arguments[0]);
                Console.WriteLine("TestCategory: {0}", Category);
                Console.WriteLine();
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("Method {0} completed without errors at {1:HH:mm:ss.ffff}", args.Method.Name, DateTime.Now);
            Console.WriteLine("TestCategory: {0}", Category);
            Console.WriteLine();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            Console.WriteLine("Exception ocurred in method {0} at {1:HH:mm:ss.ffff}: Message: {2}", args.Method.Name, DateTime.Now,
                              args.Exception.Message);
            Console.WriteLine("TestCategory: {0}", Category);
            Console.WriteLine();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Method exited: {0:ss.ffff}", DateTime.Now);
            Console.WriteLine("Value for parameter ({0}) was returned as {1}", args.Method.GetParameters().First().Name, args.Arguments[0]);
            Console.WriteLine("Method ({0}) executed and returned {1}", args.Method.Name, args.ReturnValue);
        }
    }
}
