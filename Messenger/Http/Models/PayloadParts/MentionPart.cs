using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class MentionPart : PayloadPart
{
    [JsonPropertyName("payload")]
    public MentionPartPayload Payload { get; set; }
}
