using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Formats;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class Message
{
    [JsonPropertyName("from")]
    public User From { get; set; }

    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("format")]
    public Format Format { get; set; }

    [JsonPropertyName("parts")]
    public PayloadPart[] Parts { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
