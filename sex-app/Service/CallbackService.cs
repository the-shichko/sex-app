using System;
using System.Threading.Tasks;
using sex_app.Models;
using Telegram.Bot.Args;

namespace sex_app.Service
{
    public class CallbackService : BotExecuteService<CallbackQueryEventArgs>
    {
        public CallbackService(MyTelegramBotClient botClient) : base(botClient)
        {
            ListCommands.Add(new BotCommand<CallbackQueryEventArgs, string[], Task>(
                async (e, paramList) =>
                {
                    var (message, mediaPath) = SexService.GetByFilter(Type.GetType(paramList[0]), paramList[1]);
                    await BotClient.SendPhotoAsync(e.CallbackQuery.From.Id, message, mediaPath);
                }, "sex_app.Enums."));
        }

        public override Func<CallbackQueryEventArgs, MyTelegramBotClient, string[], Task> ExecuteAction { get; set; } =
            async (e, botClient, paramList) =>
            {
                var commandModel = ListCommands[paramList[0]];
                if (commandModel != null)
                    await commandModel.Execute(e, paramList);

                var prevMessage = e.CallbackQuery.Message;
                await botClient.DeleteMessageAsync(prevMessage.Chat.Id, prevMessage.MessageId);
                // await _botClient.SendTextMessageAsync(prevMessage.Chat.Id, prevMessage.Text, replyMarkup: prevMessage.ReplyMarkup);
            };
    }
}