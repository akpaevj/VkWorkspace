using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Formats;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class PinnedMessageEventPayload
{
    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("from")]
    public User From { get; set; }

    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("format")]
    public Format Format { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}