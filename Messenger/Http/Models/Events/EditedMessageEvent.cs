using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class EditedMessageEvent : Event
{
    [JsonPropertyName("payload")]
    public EditedMessageEventPayload Payload { get; set; }
}
