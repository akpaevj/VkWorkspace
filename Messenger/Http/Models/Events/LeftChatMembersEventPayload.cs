using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

public class LeftChatMembersEventPayload
{
    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("leftMembers")]
    public User[] LeftMembers { get; set; }

    [JsonPropertyName("removedBy")]
    public User RemovedBy { get; set; }
}
