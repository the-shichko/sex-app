using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Extensions;
using sex_app.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace sex_app.Service
{
    public class CallbackService : BotExecuteService<CallbackQuery>
    {
        public CallbackService(ITelegramBotClient botClient) : base(botClient)
        {
            ListCommands.Add(new BotCommand<CallbackQuery, string[], Task>(
                async (callbackQuery, paramList) =>
                {
                    var (message, mediaPath) = SexService.GetByFilter(Type.GetType(paramList[0]), paramList[1]);
                    await BotClient.CustomSendPhotoAsync(callbackQuery.Message!.Chat.Id, message, mediaPath);
                }, "sex_app.Enums."));

            ListCommands.Add(new BotCommand<CallbackQuery, string[], Task>(
                async (callbackQuery, _) =>
                {
                    if (callbackQuery.Message != null)
                        await BotClient.CustomSendPhotoAlbumAsync(callbackQuery.Message.Chat.Id, "", SexService.GetSexSet(
                            new Dictionary<Category, int>()
                            {
                                { Category.Cunnilingus, 2 },
                                { Category.Blowjob, 2 },
                                { Category.Sex, 3 }
                            }));
                }, "Menu-Sex"));
        }

        public override Func<CallbackQuery, ITelegramBotClient, string[], Task> ExecuteAction { get; set; } =
            async (callbackQuery, botClient, paramList) =>
            {
                var commandModel = ListCommands[paramList[0]];
                if (commandModel != null)
                    await commandModel.Execute(callbackQuery, paramList);

                var newReplyMarkup = ReplyMarkupService.GetReplyMarkupByData(callbackQuery.Data);
                if (newReplyMarkup != null && callbackQuery.Message != null)
                    await botClient.EditMessageReplyMarkupAsync(callbackQuery.Message.Chat.Id,
                        callbackQuery.Message.MessageId, ReplyMarkupService.GetReplyMarkupByData(callbackQuery.Data));
                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
            };
    }
}