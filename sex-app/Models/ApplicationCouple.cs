using System;
using System.Collections.Generic;
using System.Linq;
using sex_app.Enums;

namespace sex_app.Models
{
    public class ApplicationCouple
    {
        public Guid Id { get; set; }
        public long FirstPartner { get; set; }
        public long SecondPartner { get; set; }
        public List<ToDoModel> ToDoList { get; } = new();

        public string ToDoListText =>
            "Ваш список дел:\n" + (ToDoList.Any()
                ? string.Join("\n",
                    ToDoList.Select((item, index) =>
                        $"{(item.IsExecuted ? "✅" : "⌛")} {index + 1}. "
                        + $"_{item.Text}_ {(item.IsExecuted ? $"- {item.ExecutionDate:dd MMMM yy}" : "")}"))
                : "Пусто");
    }

    public class ApplicationCouples : List<ApplicationCouple>
    {
        /// <summary>
        /// Get couple by id (Any partner identifier) 
        /// </summary>
        /// <param name="id">Any partner identifier</param>
        public ApplicationCouple this[long id] =>
            this.FirstOrDefault(x => x.FirstPartner == id || x.SecondPartner == id);

        public void ExecuteOperationToDo(OperationToDoList operationToDoList, string textToDo)
        {
        }
    }
}