using System;
using System.Threading.Tasks;
using sex_app.Models;
using Telegram.Bot;

namespace sex_app.Service
{
    /// <summary>
    /// Interface for Execute telegram actions
    /// </summary>
    /// <typeparam name="T">EventArgs from Telegram</typeparam>
    public interface IBotExecuteService<T>
    {
        public ITelegramBotClient BotClient { get; }
        public static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public Func<T, ITelegramBotClient, string[], Task> ExecuteAction { get; set; }

        public Task Execute(T e, string[] paramList);
    }

    public abstract class BotExecuteService<T> : IBotExecuteService<T>
    {
        protected BotExecuteService(ITelegramBotClient botClient)
        {
            BotClient = botClient;
        }

        protected static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public ITelegramBotClient BotClient { get; }
        public abstract Func<T, ITelegramBotClient, string[], Task> ExecuteAction { get; set; }

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