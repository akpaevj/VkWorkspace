using System.Text.Json.Serialization;

namespace VkWorkspace.Messenger.Http.Messages;

public class FilesRequest
{
    /// <summary>
    /// Id ранее загруженного файла
    /// </summary>
    [JsonPropertyName("fileId")]
    public string FileId { get; set; }
}