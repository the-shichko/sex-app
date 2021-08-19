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

        private static BotExecuteService<CallbackQuery> TgCallbackService;
        private static BotExecuteService<Message> TgCommandService;
        private static BotExecuteService<Message> TgTextService;

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
                case UpdateType.Message when update.Message is { Text: { } } && update.Message!.Text.StartsWith("/"):
                    await TgCommandService.Execute(update.Message!.Chat.Id, update.Message,
                        update.Message?.Text?.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    break;
                case UpdateType.Message when update.Message is { Text: { } } && !update.Message!.Text.StartsWith("/"):
                    await TgTextService.Execute(update.Message!.Chat.Id, update.Message,
                        update.Message?.Text?.Trim().Split("\n", StringSplitOptions.RemoveEmptyEntries));
                    break;
                case UpdateType.CallbackQuery:
                    await TgCallbackService.Execute(update.CallbackQuery!.From.Id, update.CallbackQuery,
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

            var userService = new UserService();
            var todoService = new ToDoService(userService);
            TgCommandService = new CommandService(botClient, userService);
            TgCallbackService = new CallbackService(botClient, userService);
            TgTextService = new TextService(botClient, userService, todoService);
            Console.WriteLine($"Services started");
        }
    }
}