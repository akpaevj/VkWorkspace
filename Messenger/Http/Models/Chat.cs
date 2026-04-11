using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models;

public class Chat
{
    [JsonPropertyName("chatId")]
    public string ChatId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}
