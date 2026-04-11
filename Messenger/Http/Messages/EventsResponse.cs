using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Events;

namespace VkWorkspace.Messenger.Http.Messages;

public class EventsResponse
{
    [JsonPropertyName("events")]
    public Event[] Events { get; set; }
}
