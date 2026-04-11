using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class Response
{
    /// <summary>
    /// Статус ответа
    /// </summary>
    [JsonPropertyName("ok")]
    public bool Ok { get; set; }

    /// <summary>
    /// Детальное описание результата
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
