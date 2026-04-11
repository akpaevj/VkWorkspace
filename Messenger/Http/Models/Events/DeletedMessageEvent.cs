using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class DeletedMessageEvent : Event
{
    [JsonPropertyName("payload")]
    public DeletedMessageEventPayload Payload { get; set; }
}
