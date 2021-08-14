using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Service
{
    public class MyTelegramBotClient : TelegramBotClient
    {
        public MyTelegramBotClient(string token, HttpClient httpClient = null) : base(token, httpClient)
        {
        }

        public async Task<IEnumerable<Message>> SendTextMessageAsync(IEnumerable<long> chatIds, string text,
            ParseMode parseMode = default,
            bool disableWebPagePreview = default,
            bool disableNotification = default,
            int replyToMessageId = default,
            IReplyMarkup replyMarkup = default,
            CancellationToken cancellationToken = default)
        {
            var result = new List<Message>();
            foreach (var chatId in chatIds)
            {
                result.Add(await SendTextMessageAsync(chatId, text, parseMode, disableWebPagePreview,
                    disableNotification, replyToMessageId, replyMarkup, cancellationToken));
            }

            return result;
        }

        public async Task<Message> SendPhotoAsync(long chatId, string message, string mediaPath)
        {
            await using var stream = System.IO.File.Open(mediaPath, System.IO.FileMode.Open);
            return await SendPhotoAsync(chatId,
                new InputMedia(stream, "test.png"), message, ParseMode.Markdown);
        }

        public async Task<Message[]> SendPhotoAlbumAsync(long chatId, string message, IEnumerable<string> mediaPaths)
        {
            var medias = new List<InputMediaPhoto>();
            var streams = new List<FileStream>();
            foreach (var mediaPath in mediaPaths)
            {
                var stream = System.IO.File.Open(mediaPath, FileMode.Open);
                streams.Add(stream);
                medias.Add(new InputMediaPhoto(new InputMedia(stream, stream.Name.Split("\\").LastOrDefault())));
            }

            var messageList = await SendMediaGroupAsync(medias, new ChatId(chatId));
            streams.ForEach(x => x.Dispose());
            return messageList;
        }
    }
}