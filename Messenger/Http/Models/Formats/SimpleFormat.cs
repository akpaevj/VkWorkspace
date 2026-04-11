using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Formats;

public class SimpleFormat
{
    /// <summary>
    /// Смещение форматирования
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>
    /// Длина форматирования
    /// </summary>
    [JsonPropertyName("length")]
    public int Length { get; set; }
}
