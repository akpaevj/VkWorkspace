using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class PinnedMessageEvent : Event
{
    [JsonPropertyName("payload")]
    public PinnedMessageEventPayload Payload { get; set; }
}
