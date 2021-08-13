using System;
using System.Collections.Generic;
using System.Linq;

namespace sex_app.Models
{
    public class BotCommand<TI, TP, TResult>
    {
        private readonly Func<TI, TP, TResult> _command;

        public string Text { get; }

        public BotCommand(Func<TI, TP, TResult> command, string commandText)
        {
            _command = command;
            Text = commandText;
        }

        public TResult Execute(TI messageEvent, TP paramList)
        {
            return _command(messageEvent, paramList);
        }
    }

    public class ListCommands<TI, TP, TResult> : List<BotCommand<TI, TP, TResult>>
    {
        public BotCommand<TI, TP, TResult> this[string command]
        {
            get
            {
                return this.FirstOrDefault(x =>
                           string.Equals(x.Text, command, StringComparison.CurrentCultureIgnoreCase)) ??
                       this.FirstOrDefault(x => command.ToLower().StartsWith(x.Text.ToLower()));
            }
        }
    }
}