using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Service
{
    public class MenuService
    {
        public InlineKeyboardMarkup GetSelectGender()
        {
            return new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"Мужской",
                        $"/set-gender male"),
                    InlineKeyboardButton.WithCallbackData($"Женский",
                        $"/set-gender female")
                }
            });
        }
    }
}