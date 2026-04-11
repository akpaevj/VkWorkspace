using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class NewMessageEvent : Event
{
    [JsonPropertyName("payload")]
    public NewMessageEventPayload Payload { get; set; }
}