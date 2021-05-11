using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Exception;
using sex_app.Models;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace sex_app.Service
{
    public class BotCommand<T1, T2, TResult>
    {
        private readonly Func<T1, T2, TResult> _command;

        public string Text { get; }

        public BotCommand(Func<T1, T2, TResult> command, string commandText)
        {
            _command = command;
            Text = commandText;
        }

        public TResult Execute(T1 chatId, T2 info)
        {
            return _command(chatId, info);
        }
    }

    public class ListCommands<T1, T2, TResult> : List<BotCommand<T1, T2, TResult>>
    {
        public BotCommand<T1, T2, TResult> this[string command]
        {
            get { return this.FirstOrDefault(x => x.Text == command || command.Contains(x.Text)); }
        }
    }

    public class CommandService
    {
        private static readonly ListCommands<long, MessageEventArgs, Task> BotCommands = new();
        private static readonly UserService UserService = new();
        private static readonly MenuService MenuService = new();
        private static MyTelegramBotClient _botClient;

        public static void InitCommands(MyTelegramBotClient botClient)
        {
            _botClient = botClient;

            BotCommands.Add(new BotCommand<long, MessageEventArgs, Task>(
                async (chatId, e) =>
                {
                    await UserService.AddUser(e.Message.Chat);
                    // await _botClient.SendTextMessageAsync(chatId, "Выбери пол", replyMarkup: MenuService.GetSelectGender());
                    await _botClient.SendTextMessageAsync(chatId, $"Здравствуй, *{e.Message.Chat.Username}*\n" +
                                                                  $"Отправь своей половинке этот код:",
                        ParseMode.Markdown);
                    
                    await UserService.AddUser(e.Message.Chat);
                    await _botClient.SendTextMessageAsync(chatId, $"/couple *{chatId}*", ParseMode.Markdown);
                }, "/start"));

            BotCommands.Add(new BotCommand<long, MessageEventArgs, Task>(async (chatId, e) =>
            {
                var text = e.Message.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (text.Length < 2 || !long.TryParse(text[1], out var id)) return;

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
                            $"‣ *{usersOk[1].UserName}*", ParseMode.Markdown);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }, "/couple"));
        }

        public static async Task Execute(long chatId, MessageEventArgs e)
        {
            try
            {
                await Task.Delay(100);
                var message = e.Message.Text;

                if (message.Contains("/"))
                {
                    await BotCommands[message].Execute(chatId, e);
                }
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}