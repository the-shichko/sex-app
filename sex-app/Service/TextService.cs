using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace sex_app.Service
{
    public class TextService : BotExecuteService<Message>
    {
        public TextService(ITelegramBotClient botClient, UserService userService, ToDoService toDoService) : base(
            botClient, userService)
        {
            ListCommands.Add(new BotCommand<Message, string[], Task>(async (message, paramArray) =>
            {
                var chatId = message.Chat.Id;
                var user = userService.GetUser(chatId);
                var paramList = paramArray.ToList();
                var resultMessage = user.StatusUser switch
                {
                    StatusUser.Default => throw new Exception("Статус нейтральный"),
                    StatusUser.WaitAddToDo => toDoService.AddToDo(chatId, paramList),
                    StatusUser.WaitRemoveToDo => toDoService.RemoveToDo(chatId, paramList),
                    StatusUser.WaitExecuteToDo => toDoService.ExecuteToDo(chatId, paramList),
                    _ => throw new ArgumentOutOfRangeException()
                };

                await botClient.SendTextMessageAsync(user.Id, resultMessage, ParseMode.Markdown);
                await userService.SetStatusUser(message.Chat.Id);
            }, string.Empty));
        }

        public override Func<Message, ITelegramBotClient, string[], Task> ExecuteAction { get; set; } =
            async (message, _, paramList) =>
            {
                var textExecuteModel = ListCommands[string.Empty];
                await textExecuteModel.Execute(message, paramList);
            };
    }
}