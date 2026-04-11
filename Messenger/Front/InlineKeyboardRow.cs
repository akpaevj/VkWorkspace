using System.Text.Json;
using VkWorkspace.Messenger.Http.Models.Buttons;

namespace VkWorkspace.Messenger.Helpers;

public class InlineKeyboardRow
{
    private readonly List<IButton> _buttons = [];

    public InlineKeyboardRow AddButton(IButton button)
    {
        _buttons.Add(button);

        return this;
    }

    public InlineKeyboardRow AddCallbackButton<T>(string text, T payload, ButtonStyle style = ButtonStyle.Base)
    {
        var btn = new CallbackButton()
        {
            Text = text,
            CallbackData = JsonSerializer.Serialize(payload),
            Style = style
        };
        _buttons.Add(btn);

        return this;
    }

    public InlineKeyboardRow AddUrlButton(string text, string url, ButtonStyle style = ButtonStyle.Base)
    {
        var btn = new UrlButton()
        {
            Text = text,
            Url = url,
            Style = style
        };
        _buttons.Add(btn);

        return this;
    }

    public static InlineKeyboardRow Builder(Action<InlineKeyboardRow> builder)
    {
        var k = new InlineKeyboardRow();
        builder(k);

        return k;
    }

    public IButton[] Build()
        => [.. _buttons];
}
