using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class StickerPartPayload
{
    [JsonPropertyName("fileId")]
    public string FileId { get; set; }
}
