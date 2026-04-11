using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class DeletedMessageEventPayload
{
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }

    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
