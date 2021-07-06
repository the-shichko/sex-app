using System;
using Telegram.Bot.Args;

namespace sex_app.Service
{
    public class TelegramService
    {
        private const string Token = "1714106940:AAGcEPU6IOVlIb5oOg4YaN6aJDtkbFS9MZg";
        private readonly MyTelegramBotClient _botClient;

        public TelegramService(string token = null)
        {
            _botClient = new MyTelegramBotClient(token ?? Token);
        }

        public void Start()
        {
            _botClient.StartReceiving();
            _botClient.OnMessage += OnTelegramMessage;

            MenuService.Init();
            CommandService.InitCommands(_botClient);
        }

        private static async void OnTelegramMessage(object sender, MessageEventArgs e)
        {
            await CommandService.Execute(e, e.Message.Text.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}