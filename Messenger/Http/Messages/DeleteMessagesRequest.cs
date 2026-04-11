using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class DeleteMessagesRequest(string chatId, int[] messagesId)
{
    /// <summary>
    /// Уникальный ник или id чата или пользователя. Id можно получить из входящих events (поле chatId).
    /// </summary>
    [JsonPropertyName("chatId")]
    public string ChatId { get; set; } = chatId;

    /// <summary>
    /// Id сообщений.
    /// </summary>
    [JsonPropertyName("msgId")]
    public int[] MsgId { get; set; } = messagesId;
}
