using System;
using PostSharp.Aspects;

namespace Monitoring
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionHandlingAspectAttribute : OnExceptionAspect
    {
    }
}