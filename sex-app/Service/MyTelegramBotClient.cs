using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace sex_app.Service
{
    public class MyTelegramBotClient : TelegramBotClient
    {
        public MyTelegramBotClient(string token, HttpClient httpClient = null) : base(token, httpClient)
        {
        }

        public async Task<IEnumerable<Message>> SendTextMessageAsync(IEnumerable<long> chatIds, string text, ParseMode parseMode)
        {
            var result = new List<Message>();
            foreach (var chatId in chatIds)
            {
                result.Add(await SendTextMessageAsync(chatId, text, parseMode));
            }

            return result;
        }
    }
}