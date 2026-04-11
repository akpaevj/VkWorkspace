using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models;

/// <summary>
/// Режим обработки форматирования из текста сообщения
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ParseMode
{
    /// <summary>Markdown форматирование</summary>
    [JsonPropertyName("MarkdownV2")]
    Markdown2,

    /// <summary>HTML форматирование</summary>
    [JsonPropertyName("HTML")]
    Html
}
