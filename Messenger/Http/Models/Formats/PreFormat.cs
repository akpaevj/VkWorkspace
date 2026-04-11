using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Formats;

public class PreFormat : SimpleFormat
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
}
