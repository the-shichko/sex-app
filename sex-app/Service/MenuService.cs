using System.Collections.Generic;
using System.Threading.Tasks;
using sex_app.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Service
{
    public static class MenuService
    {
        private static ReplyKeyboardMarkup MainMenu { get; set; }

        public static void Init()
        {
            MainMenu = new ReplyKeyboardMarkup
            {
                Keyboard = new IEnumerable<CustomKeyboardButton>[]
                {
                    new CustomKeyboardButton[]
                    {
                        new("/test1", new ReplyKeyboardMarkup
                        {
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("/test3", null),
                                    new("/test4", null),
                                    new("назад", null),
                                }
                            },
                        }),
                        new("/test2", null)
                    }
                }
            };
        }

        public static ReplyKeyboardMarkup GetStartMenu()
        {
            return MainMenu;
        }

        // public InlineKeyboardMarkup GetSelectGender()
        // {
        //     return new(new[]
        //     {
        //         new[]
        //         {
        //             InlineKeyboardButton.WithCallbackData($"Мужской",
        //                 $"/set-gender male"),
        //             InlineKeyboardButton.WithCallbackData($"Женский",
        //                 $"/set-gender female")
        //         }
        //     });
        // }

        public static async Task GetMenu(long chatId, string clickedText)
        {
            var 
        }
    }
}