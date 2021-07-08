using System;
using Telegram.Bot.Args;

namespace sex_app.Service
{
    public class TelegramService
    {
        private const string Token = "1714106940:AAGcEPU6IOVlIb5oOg4YaN6aJDtkbFS9MZg";

        public TelegramService(string token = null)
        {
            var botClient = new MyTelegramBotClient(token ?? Token);
            botClient.StartReceiving();
            botClient.OnMessage += OnTelegramMessage;
            
            MenuService.Init();
            SexService.Init();
            CommandService.InitCommands(botClient);
        }

        private static async void OnTelegramMessage(object sender, MessageEventArgs e)
        {
            await CommandService.Execute(e, e.Message.Text.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}