using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class SendFilePostResponse : Response
{
    /// <summary>
    /// Id вложения
    /// </summary>
    [JsonPropertyName("fileId")]
    public string FileId { get; set; }

    /// <summary>
    /// Id сообщения
    /// </summary>
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }
}