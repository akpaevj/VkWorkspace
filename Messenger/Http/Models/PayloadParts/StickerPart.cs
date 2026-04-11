using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class StickerPart : PayloadPart
{
    [JsonPropertyName("payload")]
    public StickerPartPayload Payload { get; set; }
}
