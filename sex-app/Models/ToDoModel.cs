using System;

namespace sex_app.Models
{
    public class ToDoModel
    {
        public DateTime? ExecutionDate { get; set; }
        public string Text { get; set; }
        public bool IsExecuted => ExecutionDate != default;
    }
}