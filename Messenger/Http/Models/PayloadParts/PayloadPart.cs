using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.PayloadParts;

public class PayloadPart
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
