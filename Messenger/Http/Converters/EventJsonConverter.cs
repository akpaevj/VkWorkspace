using System.Text.Json;
using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Events;

namespace VkWorkspace.Messenger.Http.Converters;

public class EventJsonConverter : JsonConverter<Event>
{
    public override Event? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("type", out var eventIdProperty))
        {
            throw new JsonException("Missing type property");
        }

        var eventType = eventIdProperty.GetString();

        // Выбираем конкретный тип на основе значения type
        Type targetType = eventType switch
        {
            "newMessage" => typeof(NewMessageEvent),
            "editedMessage" => typeof(EditedMessageEvent),
            "deletedMessage" => typeof(DeletedMessageEvent),
            "pinnedMessage" => typeof(PinnedMessageEvent),
            "unpinnedMessage" => typeof(UnpinnedMessageEvent),
            "newChatMembers" => typeof(NewChatMembersEvent),
            "leftChatMembers" => typeof(LeftChatMembersEvent),
            "callbackQuery" => typeof(CallbackQueryEvent),
            _ => throw new JsonException($"Unknown event type: {eventType}")
        };

        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        // Убираем наш конвертер из опций для внутренней десериализации
        newOptions.Converters.Remove(this);

        // Десериализуем в конкретный тип
        return (Event?)JsonSerializer.Deserialize(root.GetRawText(), targetType, newOptions);
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        newOptions.Converters.Remove(this);

        JsonSerializer.Serialize(writer, value, value.GetType(), newOptions);
    }
}
