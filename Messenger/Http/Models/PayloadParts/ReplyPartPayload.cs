using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class ReplyPartPayload
{
    [JsonPropertyName("message")]
    public Message Message { get; set; }
}
