using System;

namespace Monitoring
{
    public class EventPublisher
    {
        public static void Publish<T>(T metricEvent)
        {
            var line = string.Format(@"{0}{1}", "someUserEvent", Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\temp\logs\logfile.txt", line);
        }
    }
}