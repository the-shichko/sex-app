using System;
using Telegram.Bot.Args;

namespace sex_app.Service
{
    public class TelegramService
    {
        private const string Token = "1714106940:AAGcEPU6IOVlIb5oOg4YaN6aJDtkbFS9MZg";

        private static BotExecuteService<CallbackQueryEventArgs> CallbackService;
        private static BotExecuteService<MessageEventArgs> CommandService;

        public TelegramService(string token = null)
        {
            var botClient = new MyTelegramBotClient(token ?? Token);
            botClient.StartReceiving();
            botClient.OnMessage += OnTelegramMessage;
            botClient.OnCallbackQuery += OnCallbackQuery;

            MenuService.Init();
            SexService.Init();

            CommandService = new CommandService(botClient);
            CallbackService = new CallbackService(botClient);
        }

        private static async void OnTelegramMessage(object sender, MessageEventArgs e)
        {
            await CommandService.Execute(e, e.Message.Text.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"{e.Message.Text} - @{e.Message.Chat.Username ?? e.Message.Chat.FirstName}\n" +
                              $"\t chatId: {e.Message.Chat.Id}\n" +
                              $"\t date: {DateTime.Now:dd.MM.yyyy hh:mm}");
        }

        private static async void OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            await CallbackService.Execute(e,
                e.CallbackQuery.Data.Trim().Split("&", StringSplitOptions.RemoveEmptyEntries));

            var data = e.CallbackQuery.Data;
            var user = e.CallbackQuery.From;
            Console.WriteLine($"{data} (Callback) - @{user.Username ?? user.FirstName}\n" +
                              $"\t chatId: {user.Id}\n" +
                              $"\t date: {DateTime.Now:dd.MM.yyyy hh:mm}");
        }
    }
}