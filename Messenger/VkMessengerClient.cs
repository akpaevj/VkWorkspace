using System;
using System.Collections.Generic;
using System.Text;
using VkWorkspace.Messenger.Front;
using VkWorkspace.Messenger.Helpers;
using VkWorkspace.Messenger.Http;
using VkWorkspace.Messenger.Http.Messages;
using VkWorkspace.Messenger.Http.Models;
using VkWorkspace.Messenger.Http.Models.Buttons;
using VkWorkspace.Messenger.Http.Models.Events;
using VkWorkspace.Messenger.Http.Models.Formats;
using VkWorkspace.Messenger.Http.Models.PayloadParts;

namespace VkWorkspace.Messenger;

public class VkMessengerClient(string token)
{
    private readonly MessengerHttpClient _client = new(token);

    public async Task<SelfResponse> Self(CancellationToken cancellationToken = default)
        => await _client.GetSelf(cancellationToken);

    public async Task<string> SendText(
        string chatId, 
        string text, 
        string? replyMsgId = null,
        string? forwardChatId = null,
        string? forwardMsgId = null,
        InlineKeyboard? keyboard = null,
        Format? format = null,
        ParseMode? parseMode = null,
        CancellationToken cancellationToken = default)
    {
        var request = new SendTextRequest(chatId, text)
        {
            ReplyMsgId = replyMsgId == null ? null : [long.Parse(replyMsgId)],
            ForwardChatId = forwardChatId,
            ForwardMsgId = forwardMsgId == null ? null : [long.Parse(forwardMsgId)],
            InlineKeyboardMarkup = keyboard?.Build(),
            Format = format,
            ParseMode = parseMode
        };

        var response = await _client.SendText(request, cancellationToken);

        return response.MsgId;
    }

    public async Task EditText(
        string chatId,
        string text,
        string msgId,
        InlineKeyboard? keyboard = null,
        Format? format = null,
        ParseMode? parseMode = null,
        CancellationToken cancellationToken = default)
    {
        var request = new EditTextRequest(chatId, msgId, text)
        {
            InlineKeyboardMarkup = keyboard?.Build(),
            Format = format,
            ParseMode = parseMode
        };

        await _client.EditText(request, cancellationToken);
    }

    public async Task<SendFilePostResponse> SendFile(SendFilePostRequest request, CancellationToken cancellationToken = default)
        => await _client.SendFilePost(request, cancellationToken);

    public async Task<SendVoicePostResponse> SendVoice(SendVoicePostRequest request, CancellationToken cancellationToken = default)
        => await _client.SendVoicePost(request, cancellationToken);

    public async Task<Event[]> GetEvents(long lastEventId, long pollTime, CancellationToken cancellationToken)
    {
        var request = new EventsRequest()
        {
            LastEventId = lastEventId,
            PollTime = pollTime
        };

        var response = await _client.GetEvents(request, cancellationToken);

        return response.Events;
    }

    public async Task<VkFileInfo> DownloadFile(string fileId, CancellationToken cancellationToken)
    {
        var request = new FilesRequest()
        {
            FileId = fileId
        };

        var response = await _client.GetFiles(request, cancellationToken);

        using var client = new HttpClient();

        var data = await client.GetByteArrayAsync(response.Url, cancellationToken);

        return new VkFileInfo()
        {
            FileName = response.FileName,
            Data = data
        };
    }

    public async Task AnswerCallbackQuery(
        string queryId, 
        string? text = null, 
        bool? showAlert = null,
        string? url = null,
        CancellationToken cancellationToken = default)
    {
        var request = new AnswerCallbackQueryRequest(queryId)
        {
            Text = text,
            ShowAlert = showAlert,
            Url = url
        };

        await _client.AnswerCallbackQuery(request, cancellationToken);
    }
}
