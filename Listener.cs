using System.Diagnostics.Tracing;

internal class Listener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        base.OnEventSourceCreated(eventSource);

        if (eventSource.Name != nameof(MyEventSource))
            return;

        EnableEvents(eventSource, EventLevel.Informational, EventKeywords.None, new Dictionary<string, string?>()
        {
            ["EventCounterIntervalSec"] = "1"
        });
    }
}
