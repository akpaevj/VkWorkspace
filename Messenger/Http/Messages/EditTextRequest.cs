using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models;
using VkWorkspace.Messenger.Http.Models.Buttons;
using VkWorkspace.Messenger.Http.Models.Formats;

namespace VkWorkspace.Messenger.Http.Messages;

public class EditTextRequest(string chatId, string msgId, string text)
{
    /// <summary>
    /// Уникальный ник или id чата или пользователя. Id можно получить из входящих events (поле chatId).
    /// </summary>
    [JsonPropertyName("chatId")]
    public string ChatId { get; set; } = chatId;

    /// <summary>
    /// Id сообщения
    /// </summary>
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; } = msgId;

    /// <summary>
    /// Текст сообщения. Можно упомянуть пользователя, добавив в текст его userId в следующем формате @[userId].
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = text;

    /// <summary>
    /// Это массив массивов с описанием кнопок. Верхний уровень это массив строк кнопок, ниже уровнем массив кнопок в конкретной строке
    /// </summary>
    [JsonPropertyName("inlineKeyboardMarkup")]
    public IButton[][]? InlineKeyboardMarkup { get; set; }

    /// <summary>
    /// Описание форматирования текста
    /// </summary>
    [JsonPropertyName("format")]
    public Format? Format { get; set; }

    /// <summary>
    /// Режим обработки форматирования из текста сообщения.
    /// </summary>
    [JsonPropertyName("parseMode")]
    public ParseMode? ParseMode { get; set; }
}
