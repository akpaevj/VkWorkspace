using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class VoicePartPayload
{
    [JsonPropertyName("fileId")]
    public string FileId { get; set; }
}
