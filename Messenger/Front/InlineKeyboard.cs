using System.Security.Cryptography;
using VkWorkspace.Messenger.Http.Models.Buttons;

namespace VkWorkspace.Messenger.Helpers;

public class InlineKeyboard
{
    private readonly List<InlineKeyboardRow> _rows = [];

    public InlineKeyboard AddRow(Action<InlineKeyboardRow> rowBuilder)
    {
        var row = new InlineKeyboardRow();
        _rows.Add(row);

        rowBuilder(row);

        return this;
    }

    public static InlineKeyboard Builder(Action<InlineKeyboard> builder)
    {
        var k = new InlineKeyboard();
        builder(k);

        return k;
    }

    public IButton[][] Build()
        => [.. _rows.Select(c => c.Build())];
}
