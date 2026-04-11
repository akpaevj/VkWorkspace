using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Buttons;

public class CallbackButton : IButton
{
    /// <summary>
    /// Текст кнопки
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// Данные callback кнопки
    /// </summary>
    [JsonPropertyName("callbackData")]
    public string CallbackData { get; set; }

    /// <summary>
    /// Стиль кнопки
    /// </summary>
    [JsonPropertyName("style")]
    public ButtonStyle Style { get; set; } = ButtonStyle.Base;
}