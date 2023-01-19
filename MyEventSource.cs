using System.Diagnostics.Tracing;

[EventSource(Name = nameof(MyEventSource))]
public sealed class MyEventSource : EventSource
{
    // Just to ensure enough data is generated for any effects are easily visible.
    private const int CounterCount = 1000;

    private EventCounter[] _counters = new EventCounter[CounterCount];

    public MyEventSource()
    {
        for (var i = 0; i < CounterCount; i++)
            _counters[i] = new EventCounter("request-time-" + i, this)
            {
                DisplayName = "Request Processing Time",
                DisplayUnits = "ms"
            };

        Task.Run(async delegate
        {
            while (true)
            {
                await Task.Delay(100);

                for (var i = 0; i < CounterCount; i++)
                    _counters[i].WriteMetric(i);
            }
        });
    }
}