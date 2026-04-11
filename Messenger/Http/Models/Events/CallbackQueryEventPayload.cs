using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.PayloadParts;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class CallbackQueryEventPayload
{
    [JsonPropertyName("queryId")]
    public string QueryId { get; set; }

    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("from")]
    public User From { get; set; }

    [JsonPropertyName("message")]
    public Message Message { get; set; }

    [JsonPropertyName("callbackData")]
    public string CallbackData { get; set; }
}
