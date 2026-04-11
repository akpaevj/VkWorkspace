using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class MentionPartPayload
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
}
