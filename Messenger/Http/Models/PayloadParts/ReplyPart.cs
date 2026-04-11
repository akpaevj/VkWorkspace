using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class ReplyPart : PayloadPart
{
    [JsonPropertyName("payload")]
    public ReplyPartPayload Payload { get; set; }
}
