using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Models.Formats;

public class Format
{
    [JsonPropertyName("bold")]
    public SimpleFormat[]? Bold { get; set; }

    [JsonPropertyName("italic")]
    public SimpleFormat[]? Italic { get; set; }

    [JsonPropertyName("underline")]
    public SimpleFormat[]? Underline { get; set; }

    [JsonPropertyName("strikethrough")]
    public SimpleFormat[]? Strikethrough { get; set; }

    [JsonPropertyName("link")]
    public LinkFormat[]? Link { get; set; }

    [JsonPropertyName("mention")]
    public SimpleFormat[]? Mention { get; set; }

    [JsonPropertyName("inline_code")]
    public SimpleFormat[]? InlineCode { get; set; }

    [JsonPropertyName("pre")]
    public PreFormat[]? Pre { get; set; }

    [JsonPropertyName("ordered_list")]
    public SimpleFormat[]? OrderedList { get; set; }

    [JsonPropertyName("unordered_list")]
    public SimpleFormat[]? UnorderedList { get; set; }

    [JsonPropertyName("quote")]
    public SimpleFormat[]? Quote { get; set; }
}