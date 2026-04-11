using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class SendVoiceGetResponse : Response
{
    /// <summary>
    /// Id сообщения
    /// </summary>
    [JsonPropertyName("msgId")]
    public string MsgId { get; set; }
}
