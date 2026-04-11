using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class AnswerCallbackQueryRequest(string queryId)
{
    /// <summary>
    /// Идентификатор callback query полученного ботом
    /// </summary>
    [JsonPropertyName("queryId")]
    public string QueryId { get; set; } = queryId;

    /// <summary>
    /// Текст нотификации, который будет отображен пользователю. В случае, если текст не задан – ничего не будет отображено.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Если выставить значение в true, вместо нотификации будет показан alert
    /// </summary>
    [JsonPropertyName("showAlert")]
    public bool? ShowAlert { get; set; }

    /// <summary>
    /// URL, который будет открыт клиентским приложением
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
