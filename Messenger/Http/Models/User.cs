using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models;

public class User
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
}
