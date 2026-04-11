using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class UnpinnedMessageEvent : Event
{
    [JsonPropertyName("payload")]
    public UnpinnedMessageEventPayload Payload { get; set; }
}