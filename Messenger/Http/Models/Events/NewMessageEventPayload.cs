using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Formats;
using VkWorkspace.Messenger.Http.Models.PayloadParts;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class NewMessageEventPayload
{
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }

    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("from")]
    public User From { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("format")]
    public Format Format { get; set; }

    [JsonPropertyName("parts")]
    public PayloadPart[]? Parts { get; set; }
}