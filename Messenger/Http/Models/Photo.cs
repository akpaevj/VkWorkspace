using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models;

public class Photo
{
    /// <summary>
    /// Ссылка на фото
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
