using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace sex_app.Service
{
    public class TextService : BotExecuteService<Message>
    {
        private readonly ToDoService _toDoService;

        public TextService(ITelegramBotClient botClient, UserService userService, ToDoService toDoService) : base(
            botClient, userService)
        {
            _toDoService = toDoService;

            ListCommands.Add(new BotCommand<Message, string[], Task>(async (message, paramList) =>
            {
                var user = userService.GetUser(message.Chat.Id);
                var couple = userService.GetCouple(message.Chat.Id);
                var resultMessage = string.Empty;
                switch (user.StatusUser)
                {
                    case StatusUser.Default:
                        break;
                    case StatusUser.WaitAddToDo:
                        couple.ToDoList.AddRange(paramList.Select(text => new ToDoModel
                        {
                            Text = text
                        }));
                        resultMessage = "Успешно добавлено";
                        break;
                    case StatusUser.WaitRemoveToDo:
                        foreach (var index in paramList.Select(x => int.TryParse(x, out var i) ? i : -1))
                        {
                            if (index <= couple.ToDoList.Count && index > 0)
                                couple.ToDoList.RemoveAt(index - 1);
                        }
                        resultMessage = "Успешно удалено";
                        break;
                    case StatusUser.WaitExecuteToDo:
                        var indexExecute = int.TryParse(paramList[0], out var i)
                            ? i
                            : throw new Exception("Введено не число");
                        var toDoModel = indexExecute > 0 && indexExecute <= couple.ToDoList.Count
                            ? couple.ToDoList[indexExecute - 1]
                            : throw new Exception("Неверный индекс");
                        toDoModel.ExecutionDate = DateTime.Now;
                        resultMessage = "Успешно выполнено";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                await botClient.SendTextMessageAsync(user.Id, resultMessage);
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