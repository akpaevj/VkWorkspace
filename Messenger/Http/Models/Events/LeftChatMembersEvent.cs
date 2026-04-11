using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class LeftChatMembersEvent : Event
{
    [JsonPropertyName("payload")]
    public LeftChatMembersEventPayload Payload { get; set; }
}
