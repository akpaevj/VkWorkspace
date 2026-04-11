using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Formats;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class FilePartPayload
{
    [JsonPropertyName("fileId")]
    public string FileId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("caption")]
    public string Caption { get; set; }

    [JsonPropertyName("format")]
    public Format Format { get; set; }
}
