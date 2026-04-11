using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class CallbackQueryEvent : Event
{
    [JsonPropertyName("payload")]
    public CallbackQueryEventPayload Payload { get; set; }
}
