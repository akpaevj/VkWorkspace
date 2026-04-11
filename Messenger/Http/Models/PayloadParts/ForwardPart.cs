using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class ForwardPart : PayloadPart
{
    [JsonPropertyName("payload")]
    public ForwardPartPayload Payload { get; set; }
}
