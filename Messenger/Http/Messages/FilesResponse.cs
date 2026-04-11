using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models;

namespace VkWorkspace.Messenger.Http.Messages;

public class FilesResponse
{
    /// <summary>
    /// Тип вложения
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Размер вложения
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// Имя файла вложения
    /// </summary>
    [JsonPropertyName("filename")]
    public string FileName { get; set; }

    /// <summary>
    /// Ссылка на вложение
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}