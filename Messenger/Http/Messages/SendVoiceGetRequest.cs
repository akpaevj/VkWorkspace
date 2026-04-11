using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Buttons;

namespace VkWorkspace.Messenger.Http.Messages;

public class SendVoiceGetRequest(string chatId, string fileId)
{
    /// <summary>
    /// Уникальный ник или id чата или пользователя. Id можно получить из входящих events (поле chatId).
    /// </summary>
    [JsonPropertyName("chatId")]
    public string ChatId { get; set; } = chatId;

    /// <summary>
    /// Уникальный ник или id чата или пользователя. Id можно получить из входящих events (поле chatId).
    /// </summary>
    [JsonPropertyName("fileId")]
    public string FileId { get; set; } = fileId;

    /// <summary>
    /// Id цитируемого сообщения. Не может быть передано одновременно с параметрами forwardChatId и forwardMsgId.
    /// </summary>
    [JsonPropertyName("replyMsgId")]
    public long[]? ReplyMsgId { get; set; }

    /// <summary>
    /// Id чата, из которого будет переслано сообщение. Передается только с forwardMsgId. Не может быть передано с параметром replyMsgId.
    /// </summary>
    [JsonPropertyName("forwardChatId")]
    public string? ForwardChatId { get; set; }

    /// <summary>
    /// Id пересылаемого сообщения. Передается только с forwardChatId. Не может быть передано с параметром replyMsgId.
    /// </summary>
    [JsonPropertyName("forwardMsgId")]
    public long[]? ForwardMsgId { get; set; }

    /// <summary>
    /// Это массив массивов с описанием кнопок. Верхний уровень это массив строк кнопок, ниже уровнем массив кнопок в конкретной строке
    /// </summary>
    [JsonPropertyName("inlineKeyboardMarkup")]
    public IButton[][]? InlineKeyboardMarkup { get; set; }
}
