using System;
using System.Collections.Generic;
using System.Text;

namespace VkWorkspace.Messenger.Http;

public static class DictionaryExtension
{
    public static string ToQueryString(this Dictionary<string, string?> parameters)
    {
        var result = parameters.Select(c => $"{c.Key}={Uri.EscapeDataString(c.Value ?? "")}").ToList();

        if (result.Count > 0)
            return $"?{string.Join('&', result)}";
        else
            return "";
    }
}
