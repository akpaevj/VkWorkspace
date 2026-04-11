using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class NewChatMembersEventPayload
{
    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("newMembers")]
    public User[] NewMembers { get; set; }

    [JsonPropertyName("addedBy")]
    public User AddedBy { get; set; }
}
