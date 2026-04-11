using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class UnpinnedMessageEventPayload
{
    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
