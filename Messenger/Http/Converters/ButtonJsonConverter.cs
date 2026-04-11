using System.Text.Json;
using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models.Buttons;
using VkWorkspace.Messenger.Http.Models.Events;

namespace VkWorkspace.Messenger.Http.Converters;

public class ButtonJsonConverter : JsonConverter<IButton>
{
    public override IButton? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        var isCallback = root.TryGetProperty("callbackButton", out _);

        // Выбираем конкретный тип на основе значения флага
        Type targetType = isCallback switch
        {
            true => typeof(CallbackButton),
            _ => typeof(UrlButton),
        };

        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        // Убираем наш конвертер из опций для внутренней десериализации
        newOptions.Converters.Remove(this);

        // Десериализуем в конкретный тип
        return (IButton?)JsonSerializer.Deserialize(root.GetRawText(), targetType, newOptions);
    }

    public override void Write(Utf8JsonWriter writer, IButton value, JsonSerializerOptions options)
    {
        // Создаем новые опции, чтобы избежать рекурсии
        var newOptions = new JsonSerializerOptions(options);
        newOptions.Converters.Remove(this);

        JsonSerializer.Serialize(writer, value, value.GetType(), newOptions);
    }
}
