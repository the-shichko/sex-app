using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Models;

namespace sex_app.Service
{
    /// <summary>
    /// Interface for Execute telegram actions
    /// </summary>
    /// <typeparam name="T">EventArgs from Telegram</typeparam>
    public interface IBotExecuteService<T> where T : EventArgs
    {
        public MyTelegramBotClient BotClient { get; }
        public static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public Func<T, MyTelegramBotClient, string[], Task> ExecuteAction { get; set; }

        public Task Execute(T e, string[] paramList);
    }

    public abstract class BotExecuteService<T> : IBotExecuteService<T> where T : EventArgs
    {
        protected BotExecuteService(MyTelegramBotClient botClient)
        {
            BotClient = botClient;
        }

        protected static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public MyTelegramBotClient BotClient { get; }
        public abstract Func<T, MyTelegramBotClient, string[], Task> ExecuteAction { get; set; }

        public async Task Execute(T e, string[] paramList)
        {
            try
            {
                await ExecuteAction.Invoke(e, BotClient, paramList);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}