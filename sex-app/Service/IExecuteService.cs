using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Models;
using Telegram.Bot;

namespace sex_app.Service
{
    public interface IExecuteService<in T>
    {
        public Task Execute(long chatId, T e, string[] paramList);
    }

    /// <summary>
    /// Interface for Execute telegram actions
    /// </summary>
    /// <typeparam name="T">EventArgs from Telegram</typeparam>
    public interface IBotExecuteService<T> : IExecuteService<T>
    {
        public ITelegramBotClient BotClient { get; }
        public static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public Func<T, ITelegramBotClient, string[], Task> ExecuteAction { get; set; }
    }

    public abstract class BotExecuteService<T> : IBotExecuteService<T>
    {
        protected BotExecuteService(ITelegramBotClient botClient, UserService userService)
        {
            BotClient = botClient;
            UserService = userService;
        }

        protected static ListCommands<T, string[], Task> ListCommands { get; } = new();
        public ITelegramBotClient BotClient { get; }
        public UserService UserService { get; }
        public abstract Func<T, ITelegramBotClient, string[], Task> ExecuteAction { get; set; }

        public async Task Execute(long chatId, T e, string[] paramList)
        {
            try
            {
                await ExecuteAction.Invoke(e, BotClient, paramList);

                if (paramList.Any() && paramList[0].StartsWith("/"))
                    await UserService.SetStatusUser(chatId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}