using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using sex_app.Service;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Extensions
{
    public static class TelegramBotClientExtensions
    {
        public static async Task<Message> CustomSendPhotoAsync(this ITelegramBotClient client, long chatId,
            string message, string mediaPath)
        {
            await using var stream = System.IO.File.Open(mediaPath, FileMode.Open);
            return await client.SendPhotoAsync(chatId,
                new InputMedia(stream, "test.png"), message, ParseMode.Markdown,
                replyMarkup: ReplyMarkupService.InfoPoseMarkup($"infoPose&{mediaPath.Split('\\').LastOrDefault()}"));
        }

        public static async Task<IEnumerable<Message>> CustomSendTextMessageAsync(
            this ITelegramBotClient botClient,
            IEnumerable<ChatId> chatIds,
            string text,
            ParseMode? parseMode = default,
            IEnumerable<MessageEntity>? entities = default,
            bool? disableWebPagePreview = default,
            bool? disableNotification = default,
            int? replyToMessageId = default,
            bool? allowSendingWithoutReply = default,
            IReplyMarkup? replyMarkup = default,
            CancellationToken cancellationToken = default)
        {
            var result = new List<Message>();
            foreach (var chatId in chatIds)
            {
                result.Add(await botClient.SendTextMessageAsync(chatId, text, parseMode, entities,
                    disableWebPagePreview, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup,
                    cancellationToken));
            }

            return result;
        }

        public static async Task<Message[]> CustomSendPhotoAlbumAsync(this ITelegramBotClient client, long chatId,
            string message, IEnumerable<string> mediaPaths)
        {
            var medias = new List<InputMediaPhoto>();
            var streams = new List<FileStream>();
            foreach (var mediaPath in mediaPaths)
            {
                var stream = System.IO.File.Open(mediaPath, FileMode.Open);
                streams.Add(stream);
                medias.Add(new InputMediaPhoto(new InputMedia(stream, stream.Name.Split("\\").Last())));
            }

            var messageList = await client.SendMediaGroupAsync(new ChatId(chatId), medias);
            streams.ForEach(x => x.Dispose());
            return messageList;
            return null;
        }
    }
}