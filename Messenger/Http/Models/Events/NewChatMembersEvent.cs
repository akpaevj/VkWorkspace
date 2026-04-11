using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class NewChatMembersEvent : Event
{
    [JsonPropertyName("payload")]
    public NewChatMembersEventPayload Payload { get; set; }
}