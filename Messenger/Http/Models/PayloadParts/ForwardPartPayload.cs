using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class ForwardPartPayload
{
    [JsonPropertyName("message")]
    public Message Message { get; set; }
}
