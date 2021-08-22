using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Extensions;
using sex_app.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace sex_app.Service
{
    public class CommandService : BotExecuteService<Message>
    {
        public CommandService(ITelegramBotClient botClient, UserService userService) : base(botClient, userService)
        {
            ListCommands.Add(new BotCommand<Message, string[], Task>(async (message, _) =>
            {
                var chatId = message.Chat.Id;
                await UserService.AddUser(message.Chat);

                await BotClient.SendTextMessageAsync(chatId, $"Здравствуй, *{message.Chat.Username}*\n" +
                                                             $"Отправь своей половинке этот код:",
                    ParseMode.Markdown);
                await BotClient.SendTextMessageAsync(chatId, $"/couple *{chatId}*", ParseMode.Markdown);
            }, "/start"));

            ListCommands.Add(new BotCommand<Message, string[], Task>(
                async (message, _) => { await ReplyMarkupService.MenuMarkup.Send(message.Chat.Id, botClient); },
                "/menu"));

            ListCommands.Add(new BotCommand<Message, string[], Task>(
                async (message, _) =>
                {
                    var (messageText, mediaPath) = SexService.GetRandomPositionNew();
                    await BotClient.CustomSendPhotoAsync(message.Chat.Id, messageText, mediaPath);
                }, "/random"));

            ListCommands.Add(new BotCommand<Message, string[], Task>(
                async (message, _) =>
                {
                    await ReplyMarkupService.TodoMarkup.Send(message.Chat.Id, botClient,
                        UserService.GetCouple(message.Chat.Id).ToDoListText);
                }, "/todo"));

            // BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, paramList) =>
            // {
            //     var chatId = e.Message.Chat.Id;
            //     if (paramList.Length == 0 || !long.TryParse(paramList[0], out var id)) return;
            //
            //     var (coupleId, result) = await UserService.AddCouple(chatId, id);
            //     switch (result)
            //     {
            //         case CoupleResult.CoupleExist:
            //             var users = UserService.GetUsersByCoupleId(coupleId.Value);
            //             await BotClient.SendTextMessageAsync(chatId, "Пара уже добавлена.\n" +
            //                                                          $"‣ *{users[0].UserName}*\n" +
            //                                                          $"‣ *{users[1].UserName}*", ParseMode.Markdown);
            //             break;
            //         case CoupleResult.FirstUserNull:
            //             await BotClient.SendTextMessageAsync(chatId, "Войдите в систему (/start)\n");
            //             break;
            //         case CoupleResult.SecondUserNull:
            //             await BotClient.SendTextMessageAsync(chatId, "Пользователь не существует\n");
            //             break;
            //         case CoupleResult.Ok:
            //             var usersOk = UserService.GetUsersByCoupleId(coupleId.Value);
            //
            //             await BotClient.SendTextMessageAsync(usersOk.Select(x => x.Id), "Добавлена пара:\n" +
            //                 $"‣ *{usersOk[0].UserName}*\n" +
            //                 $"‣ *{usersOk[1].UserName}*", ParseMode.Markdown, replyMarkup: MenuService.GetStartMenu());
            //             break;
            //         default:
            //             throw new ArgumentOutOfRangeException();
            //     }
            // }, "/couple"));
            //
            // BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, _) =>
            // {
            //     var chatId = e.Message.Chat.Id;
            //     var couple = UserService.GetCouple(chatId);
            //
            //     await BotClient.SendTextMessageAsync(chatId,
            //         couple != null
            //             ? $"About: \n{couple.First().UserName} & {couple.Last().UserName} ❤"
            //             : "Инфрмации нет");
            // }, "/coupleInfo"));
            //

            //
        }

        public override Func<Message, ITelegramBotClient, string[], Task> ExecuteAction { get; set; } =
            async (message, _, paramList) =>
            {
                if (paramList[0].Contains("/"))
                {
                    var commandModel = ListCommands[paramList[0]];
                    if (commandModel != null)
                    {
                        await commandModel.Execute(message, paramList.Skip(1).ToArray());
                    }
                }
            };
    }
}