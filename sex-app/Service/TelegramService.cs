using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace sex_app.Service
{
    public class TelegramService
    {
        private const string Token = "1988557630:AAFG1fzjHl6fglSkf5a4hwveLBFjy3Uannw";

        private static BotExecuteService<CallbackQuery> CallbackService;
        private static BotExecuteService<Message> CommandService;

        private static readonly ReceiverOptions _receiverOptions = new()
        {
            AllowedUpdates = new[]
                { UpdateType.Message, UpdateType.CallbackQuery, UpdateType.InlineQuery }
        };

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await CommandService.Execute(update.Message,
                        update.Message?.Text?.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    break;
                case UpdateType.CallbackQuery:
                    await CallbackService.Execute(update.CallbackQuery,
                        update.CallbackQuery?.Data?.Trim().Split("&", StringSplitOptions.RemoveEmptyEntries));
                    break;
                case UpdateType.InlineQuery:
                    //todo InlineQuery
                    break;
                default:
                    throw new Exception($"Implement update.Type - {update.Type}");
            }
        }

        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(337383405, apiRequestException.ToString(),
                    cancellationToken: cancellationToken);
            }
        }

        public TelegramService(string token = null)
        {
            var botClient = new TelegramBotClient(token ?? Token);
            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, _receiverOptions);
            Console.WriteLine($"Bot started - {botClient.GetMeAsync().GetAwaiter().GetResult().Username}");

            MenuService.Init();
            ReplyMarkupService.Init();
            SexService.Init();

            CommandService = new CommandService(botClient);
            CallbackService = new CallbackService(botClient);
            Console.WriteLine($"Services started");
        }
    }
}