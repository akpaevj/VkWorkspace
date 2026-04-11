using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class FilePart : PayloadPart
{
    [JsonPropertyName("payload")]
    public FilePartPayload Payload { get; set; }
}
