using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class SendFileGetResponse : Response
{
    /// <summary>
    /// Id сообщения
    /// </summary>
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }
}