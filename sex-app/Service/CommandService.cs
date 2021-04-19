using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

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
            get { return this.FirstOrDefault(x => x.Text == command || x.Text.Contains(command)); }
        }
    }

    public class CommandService
    {
        private static readonly ListCommands<long, MessageEventArgs, Task> BotCommands = new();
        private static TelegramBotClient _botClient;

        public static void InitCommands(TelegramBotClient botClient)
        {
            _botClient = botClient;

            BotCommands.Add(new BotCommand<long, MessageEventArgs, Task>(
                async (chatId, e) =>
                {
                    await _botClient.SendTextMessageAsync(chatId, $"Здравствуй {e.Message.Chat.Username}");
                }, "/start"));
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}