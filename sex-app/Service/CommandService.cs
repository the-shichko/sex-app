using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Exceptions;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;
using Location = sex_app.Enums.Location;

namespace sex_app.Service
{
    public class BotCommand<TI, TP, TResult>
    {
        private readonly Func<TI, TP, TResult> _command;

        public string Text { get; }

        public BotCommand(Func<TI, TP, TResult> command, string commandText)
        {
            _command = command;
            Text = commandText;
        }

        public TResult Execute(TI messageEvent, TP paramList)
        {
            return _command(messageEvent, paramList);
        }
    }

    public class ListCommands<TI, TP, TResult> : List<BotCommand<TI, TP, TResult>>
    {
        public BotCommand<TI, TP, TResult> this[string command]
        {
            get
            {
                return this.FirstOrDefault(x =>
                           string.Equals(x.Text, command, StringComparison.CurrentCultureIgnoreCase)) ??
                       this.FirstOrDefault(x => command.ToLower().StartsWith(x.Text.ToLower()));
            }
        }
    }

    public static class CommandService
    {
        private static readonly ListCommands<MessageEventArgs, string[], Task> BotCommands = new();
        private static readonly ListCommands<CallbackQueryEventArgs, string[], Task> BotCallbacks = new();
        private static readonly UserService UserService = new();
        private static MyTelegramBotClient _botClient;

        public static void InitCommands(MyTelegramBotClient botClient)
        {
            _botClient = botClient;

            #region Commands

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    var chatId = e.Message.Chat.Id;
                    await UserService.AddUser(e.Message.Chat);

                    // await _botClient.SendTextMessageAsync(chatId, "Выбери пол", replyMarkup: MenuService.GetSelectGender());
                    await _botClient.SendTextMessageAsync(chatId, $"Здравствуй, *{e.Message.Chat.Username}*\n" +
                                                                  $"Отправь своей половинке этот код:",
                        ParseMode.Markdown);
                    await _botClient.SendTextMessageAsync(chatId, $"/couple *{chatId}*", ParseMode.Markdown);
                }, "/start"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, paramList) =>
            {
                var chatId = e.Message.Chat.Id;
                if (paramList.Length == 0 || !long.TryParse(paramList[0], out var id)) return;

                var (coupleId, result) = await UserService.AddCouple(chatId, id);
                switch (result)
                {
                    case CoupleResult.CoupleExist:
                        var users = UserService.GetUsersByCoupleId(coupleId.Value);
                        await _botClient.SendTextMessageAsync(chatId, "Пара уже добавлена.\n" +
                                                                      $"‣ *{users[0].UserName}*\n" +
                                                                      $"‣ *{users[1].UserName}*", ParseMode.Markdown);
                        break;
                    case CoupleResult.FirstUserNull:
                        await _botClient.SendTextMessageAsync(chatId, "Войдите в систему (/start)\n");
                        break;
                    case CoupleResult.SecondUserNull:
                        await _botClient.SendTextMessageAsync(chatId, "Пользователь не существует\n");
                        break;
                    case CoupleResult.Ok:
                        var usersOk = UserService.GetUsersByCoupleId(coupleId.Value);

                        await _botClient.SendTextMessageAsync(usersOk.Select(x => x.Id), "Добавлена пара:\n" +
                            $"‣ *{usersOk[0].UserName}*\n" +
                            $"‣ *{usersOk[1].UserName}*", ParseMode.Markdown, replyMarkup: MenuService.GetStartMenu());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }, "/couple"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, _) =>
            {
                var chatId = e.Message.Chat.Id;
                var couple = UserService.GetCouple(chatId);

                if (couple != null)
                    await _botClient.SendTextMessageAsync(chatId,
                        $"About: \n{couple.First().UserName} & {couple.Last().UserName} ❤");
            }, "/coupleInfo"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id, Category.Cunnilingus); }, "/cunnilingus"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id, Category.Blowjob); }, "/blowjob"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id, Category.Position69); }, "/69"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id, Category.OralSex); }, "/oralSex"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id, Category.Sex); }, "/sex"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) => { await SendImagePosition(e.Message.Chat.Id); }, "/fullRandom"));

            static async Task SendImagePosition(long chatId, Category? category = null)
            {
                var (message, mediaPath) = SexService.GetRandomPositionNew(category);
                await SendImage(chatId, message, mediaPath);
            }

            static async Task SendImage(long chatId, string message, string mediaPath)
            {
                await using var stream = File.Open(mediaPath, FileMode.Open);
                await _botClient.SendPhotoAsync(chatId,
                    new InputMedia(stream, "test.png"), message, ParseMode.Markdown);
            }

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите уровень",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Level)));
                }, "/level"));
            
            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите положение",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Location)));
                }, "/location"));

            #endregion

            #region Callbacks

            BotCallbacks.Add(new BotCommand<CallbackQueryEventArgs, string[], Task>(
                async (e, paramList) =>
                {
                    var (message, mediaPath) = SexService.GetByFilter(Type.GetType(paramList[0]), paramList[1]);
                    await SendImage(e.CallbackQuery.From.Id, message, mediaPath);
                }, "sex_app.Enums."));

            #endregion
        }

        public static async Task Execute(MessageEventArgs e, string[] paramList)
        {
            try
            {
                if (paramList[0].Contains("/"))
                {
                    var commandModel = BotCommands[paramList[0]];
                    if (commandModel != null)
                        await commandModel.Execute(e, paramList.Skip(1).ToArray());
                }

                var (path, menu) = await UserService.GetMenuForUser(e.Message.Chat.Id, paramList[0]);
                await _botClient.SendTextMessageAsync(e.Message.Chat.Id, path,
                    replyMarkup: menu);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static async Task ExecuteCallback(CallbackQueryEventArgs e, string[] paramList)
        {
            try
            {
                var commandModel = BotCallbacks[paramList[0]];
                if (commandModel != null)
                    await commandModel.Execute(e, paramList);

                var prevMessage = e.CallbackQuery.Message;
                await _botClient.DeleteMessageAsync(prevMessage.Chat.Id, prevMessage.MessageId);
                await _botClient.SendTextMessageAsync(prevMessage.Chat.Id, prevMessage.Text, replyMarkup: prevMessage.ReplyMarkup);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}