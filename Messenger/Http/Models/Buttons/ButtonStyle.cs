using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Buttons;

/// <summary>
/// Стиль кнопки
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ButtonStyle
{
    [JsonPropertyName("base")]
    Base,

    [JsonPropertyName("attention")]
    Attention,

    [JsonPropertyName("primary")]
    Primary
}