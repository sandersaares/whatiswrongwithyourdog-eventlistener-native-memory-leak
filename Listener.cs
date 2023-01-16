using System.Diagnostics.Tracing;

internal class Listener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        base.OnEventSourceCreated(eventSource);

        EnableEvents(eventSource, EventLevel.Informational, EventKeywords.None, new Dictionary<string, string?>()
        {
            ["EventCounterIntervalSec"] = "1"
        });
    }
}
