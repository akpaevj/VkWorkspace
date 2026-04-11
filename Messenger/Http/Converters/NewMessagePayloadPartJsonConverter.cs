using System.Text.Json;
using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Events;
using VkWorkspace.Messenger.Http.Models.PayloadParts;

namespace VkWorkspace.Messenger.Http.Converters;

public class NewMessagePayloadPartJsonConverter : JsonConverter<PayloadPart>
{
    public override PayloadPart? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("type", out var eventIdProperty))
        {
            throw new JsonException("Missing type property");
        }

        var partType = eventIdProperty.GetString();

        // Выбираем конкретный тип на основе значения event id
        Type targetType = partType switch
        {
            "sticker" => typeof(StickerPart),
            "mention" => typeof(MentionPart),
            "voice" => typeof(VoicePart),
            "file" => typeof(FilePart),
            "forward" => typeof(ForwardPart),
            "reply" => typeof(ReplyPart),
            "inlineKeyboardMarkup" => typeof(InlineKeyboardMarkupPart),
            _ => throw new JsonException($"Unknown part type: {partType}")
        };

        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        // Убираем наш конвертер из опций для внутренней десериализации
        newOptions.Converters.Remove(this);

        // Десериализуем в конкретный тип
        return (PayloadPart?)JsonSerializer.Deserialize(root.GetRawText(), targetType, newOptions);
    }

    public override void Write(Utf8JsonWriter writer, PayloadPart value, JsonSerializerOptions options)
    {
        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        newOptions.Converters.Remove(this);

        JsonSerializer.Serialize(writer, value, value.GetType(), newOptions);
    }
}
