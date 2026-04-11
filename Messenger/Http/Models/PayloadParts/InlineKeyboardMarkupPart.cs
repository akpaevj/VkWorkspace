using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Buttons;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class InlineKeyboardMarkupPart : PayloadPart
{
    [JsonPropertyName("payload")]
    public IButton[][] Payload { get; set; }
}