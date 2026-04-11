using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using VkWorkspace.Messenger.Http.Converters;
using VkWorkspace.Messenger.Http.Messages;

namespace VkWorkspace.Messenger.Http;

class MessengerHttpClient
{
    private readonly string _token;
    private readonly JsonSerializerOptions _options;
    private HttpClient _client;
    private bool disposedValue;

    public MessengerHttpClient(string token)
    {
        _token = token;

        _options = new JsonSerializerOptions();
        _options.Converters.Add(new ButtonJsonConverter());
        _options.Converters.Add(new EventJsonConverter());
        _options.Converters.Add(new NewMessagePayloadPartJsonConverter());

        _client = new HttpClient
        {
            BaseAddress = new Uri("https://myteam.mail.ru/")
        };
    }

    #region Self

    public async Task<SelfResponse> GetSelf(CancellationToken cancellationToken = default)
        => await GetAsync<SelfResponse>(BuildUri("self/get"), cancellationToken);

    #endregion

    #region Messages

    public async Task<SendTextResponse> SendText(SendTextRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId },
            { "text", request.Text }
        };

        if (request.ReplyMsgId != null)
            parameters.Add("replyMsgId", string.Join(',', request.ReplyMsgId));

        if (request.ForwardChatId != null)
            parameters.Add("forwardChatId", request.ForwardChatId);

        if (request.ForwardMsgId != null)
            parameters.Add("forwardMsgId", string.Join(',', request.ForwardMsgId));

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        if (request.Format != null)
            parameters.Add("format", JsonSerializer.Serialize(request.Format, _options));

        if (request.ParseMode != null)
            parameters.Add("parseMode", JsonSerializer.Serialize(request.ParseMode, _options));

        return await GetAsync<SendTextResponse>(BuildUri("messages/sendText", parameters), cancellationToken);
    }

    public async Task<SendFileGetResponse> SendFileGet(SendFileGetRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId },
            { "fileId", request.FileId }
        };

        if (request.Caption != null)
            parameters.Add("caption", request.Caption);

        if (request.ReplyMsgId != null)
            parameters.Add("replyMsgId", string.Join(',', request.ReplyMsgId));

        if (request.ForwardChatId != null)
            parameters.Add("forwardChatId", request.ForwardChatId);

        if (request.ForwardMsgId != null)
            parameters.Add("forwardMsgId", string.Join(',', request.ForwardMsgId));

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        if (request.Format != null)
            parameters.Add("format", JsonSerializer.Serialize(request.Format, _options));

        if (request.ParseMode != null)
            parameters.Add("parseMode", JsonSerializer.Serialize(request.ParseMode, _options));

        return await GetAsync<SendFileGetResponse>(BuildUri("messages/sendFile", parameters), cancellationToken);
    }

    public async Task<SendFilePostResponse> SendFilePost(SendFilePostRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId }
        };

        if (request.Caption != null)
            parameters.Add("caption", request.Caption);

        if (request.ReplyMsgId != null)
            parameters.Add("replyMsgId", string.Join(',', request.ReplyMsgId));

        if (request.ForwardChatId != null)
            parameters.Add("forwardChatId", request.ForwardChatId);

        if (request.ForwardMsgId != null)
            parameters.Add("forwardMsgId", string.Join(',', request.ForwardMsgId));

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        if (request.Format != null)
            parameters.Add("format", JsonSerializer.Serialize(request.Format, _options));

        if (request.ParseMode != null)
            parameters.Add("parseMode", JsonSerializer.Serialize(request.ParseMode, _options));

        return await PostFileAsync<SendFilePostResponse>(BuildUri("messages/sendFile", parameters), request.DataStream, "file", request.FileName ?? "", cancellationToken);
    }

    public async Task<SendVoiceGetResponse> SendVoiceGet(SendVoiceGetRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId },
            { "fileId", request.FileId }
        };

        if (request.ReplyMsgId != null)
            parameters.Add("replyMsgId", string.Join(',', request.ReplyMsgId));

        if (request.ForwardChatId != null)
            parameters.Add("forwardChatId", request.ForwardChatId);

        if (request.ForwardMsgId != null)
            parameters.Add("forwardMsgId", string.Join(',', request.ForwardMsgId));

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        return await GetAsync<SendVoiceGetResponse>(BuildUri("messages/sendVoice", parameters), cancellationToken);
    }

    public async Task<SendVoicePostResponse> SendVoicePost(SendVoicePostRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId }
        };

        if (request.ReplyMsgId != null)
            parameters.Add("replyMsgId", string.Join(',', request.ReplyMsgId));

        if (request.ForwardChatId != null)
            parameters.Add("forwardChatId", request.ForwardChatId);

        if (request.ForwardMsgId != null)
            parameters.Add("forwardMsgId", string.Join(',', request.ForwardMsgId));

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        return await PostFileAsync<SendVoicePostResponse>(BuildUri("messages/sendVoice", parameters), request.DataStream, "file", request.FileName, cancellationToken: cancellationToken);
    }

    public async Task<Response> EditText(EditTextRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId },
            { "msgId", request.MsgId },
            { "text", request.Text }
        };

        if (request.InlineKeyboardMarkup != null)
            parameters.Add("inlineKeyboardMarkup", JsonSerializer.Serialize(request.InlineKeyboardMarkup, _options));

        if (request.Format != null)
            parameters.Add("format", JsonSerializer.Serialize(request.Format, _options));

        if (request.ParseMode != null)
            parameters.Add("parseMode", JsonSerializer.Serialize(request.ParseMode, _options));

        return await GetAsync<Response>(BuildUri("messages/editText", parameters), cancellationToken);
    }

    public async Task<Response> DeleteMessages(DeleteMessagesRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "chatId", request.ChatId }
        };

        if (request.MsgId != null)
            parameters.Add("msgId", string.Join(',', request.MsgId));

        return await GetAsync<Response>(BuildUri("messages/deleteMessages", parameters), cancellationToken);
    }

    public async Task<Response> AnswerCallbackQuery(AnswerCallbackQueryRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "queryId", request.QueryId }
        };

        if (request.Text != null)
            parameters.Add("text", Uri.UnescapeDataString(request.Text));

        if (request.ShowAlert != null)
            parameters.Add("showAlert", request.ShowAlert.ToString()?.ToLower());

        if (request.Url != null)
            parameters.Add("url", request.Url);

        return await GetAsync<Response>(BuildUri("messages/answerCallbackQuery", parameters), cancellationToken);
    }

    #endregion

    #region Files

    public async Task<FilesResponse> GetFiles(FilesRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();

        if (request.FileId != null)
            parameters.Add("fileId", request.FileId);

        return await GetAsync<FilesResponse>(BuildUri("files/getInfo", parameters), cancellationToken);
    }

    #endregion

    #region Events

    public async Task<EventsResponse> GetEvents(EventsRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>()
        {
            { "lastEventId", request.LastEventId.ToString() },
            { "pollTime", request.PollTime.ToString() }
        };

        return await GetAsync<EventsResponse>(BuildUri("events/get", parameters), cancellationToken);
    }

    #endregion

    #region Private helper methods

    private async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        using var response = await _client.GetAsync(uri, cancellationToken);
        await EnsureSuccessStatusCode(response);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<T>(_options, cancellationToken) ?? throw new InvalidOperationException("Response is null");
        ThrowIfNotOk(deserializedResponse);

        return deserializedResponse;
    }

    private async Task<T> PostFileAsync<T>(Uri uri, Stream data, string name = "", string fileName = "", CancellationToken cancellationToken = default)
    {
        using var streamContent = new StreamContent(data);
        if (!string.IsNullOrEmpty(fileName))
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(MimeTypes.GetMimeType(fileName));

        using var formData = new MultipartFormDataContent();

        if (string.IsNullOrEmpty(name))
            formData.Add(streamContent);
        else
            formData.Add(streamContent, name, Uri.EscapeDataString(fileName));

        // Удалим кавычки в boundary, т.к. VK некорректно читает такое сообщение
        var boundary = formData.Headers.ContentType?.Parameters.First(p => p.Name == "boundary");
        boundary?.Value = boundary?.Value?.Replace("\"", string.Empty);

        using var response = await _client.PostAsync(uri, formData, cancellationToken);
        await EnsureSuccessStatusCode(response);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<T>(_options, cancellationToken) ?? throw new InvalidOperationException("Response is null");
        ThrowIfNotOk(deserializedResponse);

        return deserializedResponse;
    }

    private async Task<T> PostAsync<T, T2>(Uri uri, T2? content, CancellationToken cancellationToken = default)
    {
        var d = JsonSerializer.Serialize(content);
        using var response = await _client.PostAsJsonAsync(uri, content, _options, cancellationToken);
        await EnsureSuccessStatusCode(response);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<T>(_options, cancellationToken) ?? throw new InvalidOperationException("Response is null");
        ThrowIfNotOk(deserializedResponse);

        return deserializedResponse;
    }

    private async Task<T> PutAsync<T, T2>(Uri uri, T2? content, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PutAsJsonAsync(uri, content, _options, cancellationToken);
        await EnsureSuccessStatusCode(response);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<T>(_options, cancellationToken) ?? throw new InvalidOperationException("Response is null");
        ThrowIfNotOk(deserializedResponse);

        return deserializedResponse;
    }

    private async Task<T> DeleteAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        using var response = await _client.DeleteAsync(uri, cancellationToken);
        await EnsureSuccessStatusCode(response);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<T>(_options, cancellationToken) ?? throw new InvalidOperationException("Response is null");
        ThrowIfNotOk(deserializedResponse);

        return deserializedResponse;
    }

    private static void ThrowIfNotOk<T>(T response)
    {
        if (response is Response r && !r.Ok)
            throw new Exception(string.IsNullOrEmpty(r.Description) ? "Ошибка выполнения запроса" : r.Description);
    }

    private async Task EnsureSuccessStatusCode(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var statusCode = response.StatusCode;
        var content = await response.Content.ReadAsStringAsync();

        var errorMessage = statusCode switch
        {
            HttpStatusCode.BadRequest => $"Недействительный запрос (400): {content}",
            HttpStatusCode.Unauthorized => $"Ошибка аутентификации (401): {content}",
            HttpStatusCode.NotFound => $"Ресурс не найден (404): {content}",
            HttpStatusCode.MethodNotAllowed => $"Метод не допускается (405): {content}",
            HttpStatusCode.TooManyRequests => $"Превышено количество запросов (429): {content}",
            HttpStatusCode.ServiceUnavailable => $"Сервис недоступен (503): {content}",
            _ => $"HTTP ошибка {(int)statusCode} ({statusCode}): {content}"
        };

        throw new HttpRequestException(errorMessage, null, statusCode);
    }

    private Uri BuildUri(string uri)
        => BuildUri(uri, []);

    private Uri BuildUri(string uri, Dictionary<string, string?> parameters)
    {
        parameters.TryAdd("token", _token);

        return new UriBuilder(_client.BaseAddress!)
        {
            Path = "bot/v1/" + uri,
            Query = parameters.ToQueryString(),
        }.Uri;
    }

    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _client?.Dispose();
                _client = null!;
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
