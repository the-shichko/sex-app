using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

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

        public TResult Execute(TI updateHandleObject, TP paramList)
        {
            return _command(updateHandleObject, paramList);
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