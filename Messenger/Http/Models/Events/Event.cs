using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Events;

/// <summary>
/// Event представляет различные типы событий, произошедших в чате
/// </summary>
public class Event
{
    [JsonPropertyName("eventId")]
    public int EventId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
