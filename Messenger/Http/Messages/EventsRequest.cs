using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class EventsRequest
{
    /// <summary>
    /// Id последнего известного события
    /// </summary>
    [JsonPropertyName("lastEventId")]
    public long LastEventId { get; set; }

    /// <summary>
    /// Время удержания соединения (в секундах)
    /// </summary>
    [JsonPropertyName("pollTime")]
    public long PollTime { get; set; }
}
