using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class VoicePart : PayloadPart
{
    [JsonPropertyName("payload")]
    public VoicePartPayload Payload { get; set; }
}
