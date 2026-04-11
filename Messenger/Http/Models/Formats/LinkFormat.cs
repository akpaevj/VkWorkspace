using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Formats;

public class LinkFormat : SimpleFormat
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
