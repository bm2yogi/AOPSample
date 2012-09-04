using System;
using PostSharp.Aspects;

namespace Monitoring
{
    [Serializable]
    public class BaseAspect : OnMethodBoundaryAspect
    {
    }
}