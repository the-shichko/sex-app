using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Exceptions;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

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
            get { return this.FirstOrDefault(x => x.Text == command || command.Contains(x.Text)); }
        }
    }

    public class CommandService
    {
        private static readonly ListCommands<MessageEventArgs, string[], Task> BotCommands = new();
        private static readonly UserService UserService = new();
        private static MyTelegramBotClient _botClient;

        public static void InitCommands(MyTelegramBotClient botClient)
        {
            _botClient = botClient;

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, paramList) =>
                {
                    var chatId = e.Message.Chat.Id;
                    await UserService.AddUser(e.Message.Chat);
                    // await _botClient.SendTextMessageAsync(chatId, "Выбери пол", replyMarkup: MenuService.GetSelectGender());
                    await _botClient.SendTextMessageAsync(chatId, $"Здравствуй, *{e.Message.Chat.Username}*\n" +
                                                                  $"Отправь своей половинке этот код:",
                        ParseMode.Markdown);

                    await UserService.AddUser(e.Message.Chat);
                    await _botClient.SendTextMessageAsync(chatId, $"/couple *{chatId}*", ParseMode.Markdown);
                }, "/start"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, paramList) =>
            {
                var chatId = e.Message.Chat.Id;
                if (paramList.Length < 2 || !long.TryParse(paramList[1], out var id)) return;

                var (coupleId, result) = await UserService.AddCouple(id, chatId);
                switch (result)
                {
                    case CoupleResult.CoupleExist:
                        var users = UserService.GetUsersByCoupleId(coupleId.Value);
                        await _botClient.SendTextMessageAsync(chatId, "Пара уже добавлена.\n" +
                                                                      $"‣ *{users[0].UserName}*\n" +
                                                                      $"‣ *{users[1].UserName}*", ParseMode.Markdown);
                        break;
                    case CoupleResult.UserNull:
                        await _botClient.SendTextMessageAsync(chatId, "Пользователь не существует.\n");
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
            
            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, paramList) =>
            {
                await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "123", replyMarkup: MenuService.SendMenu("fsd"));
            }, "/test1"));
        }

        public static async Task Execute(MessageEventArgs e, string[] paramList)
        {
            try
            {
                await Task.Delay(100);
                if (paramList[0].Contains("/"))
                    await BotCommands[paramList[0]].Execute(e, paramList);
                
                await UserService.GetMenu(e.Message.Chat.Id, paramList[0]);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}