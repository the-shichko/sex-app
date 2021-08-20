using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Models;
using Telegram.Bot.Types;

namespace sex_app.Service
{
    public class ToDoService
    {
        private readonly UserService _userService;

        private const string UseToDoMessage = "Используйте команду /todo для просмотра";
        public ToDoService(UserService userService)
        {
            _userService = userService;
        }

        public string AddToDo(long chatId, IEnumerable<string> values)
        {
            var couple = _userService.GetCouple(chatId);
            couple.ToDoList.AddRange(values.Select(text => new ToDoModel
            {
                Text = text
            }));

            return $"*Успешно добавлено*\n{UseToDoMessage}";
        }

        public string RemoveToDo(long chatId, IEnumerable<string> values)
        {
            var couple = _userService.GetCouple(chatId);
            var removeItems = (from index in values.Select(x => int.TryParse(x, out var i) ? i : -1)
                where index <= couple.ToDoList.Count && index > 0
                select couple.ToDoList[index - 1]).ToList();

            foreach (var removeItem in removeItems)
            {
                couple.ToDoList.Remove(removeItem);
            }
            return $"*Успешно удалено*\n{UseToDoMessage}";
        }

        public string ExecuteToDo(long chatId, List<string> values)
        {
            var couple = _userService.GetCouple(chatId);
            var indexExecute = int.TryParse(values[0], out var i)
                ? i
                : throw new Exception("Введено не число");
            var toDoModel = indexExecute > 0 && indexExecute <= couple.ToDoList.Count
                ? couple.ToDoList[indexExecute - 1]
                : throw new Exception("Неверный индекс");
            toDoModel.ExecutionDate = DateTime.Now;

            var many = values.Count > 1 ? "ы" : "";
            return $"*Пункт{many} выполнен{many}*\n{UseToDoMessage}";
        }
    }
}