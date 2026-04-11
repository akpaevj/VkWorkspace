using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Buttons;

public class UrlButton : IButton
{
    /// <summary>
    /// Текст кнопки
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// Url кнопки
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Стиль кнопки
    /// </summary>
    [JsonPropertyName("style")]
    public ButtonStyle Style { get; set; } = ButtonStyle.Base;
}
