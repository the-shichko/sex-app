using System.Collections.Generic;
using sex_app.Models;

namespace sex_app.Service
{
    public static class MenuService
    {
        private static CustomReplyReplyKeyboardMarkup MainMenu { get; set; }

        public static void Init()
        {
            MainMenu = new CustomReplyReplyKeyboardMarkup
            {
                Keyboard = new IEnumerable<CustomKeyboardButton>[]
                {
                    new CustomKeyboardButton[]
                    {
                        new("/test1", new CustomReplyReplyKeyboardMarkup
                        {
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("/test3"),
                                    new("/test4"),
                                    new("назад", true),
                                }
                            },
                        }),
                        new("/test2")
                    }
                }
            };
            
            SetPrev(MainMenu);
        }

        private static void SetPrev(CustomReplyReplyKeyboardMarkup baseMenu,
            CustomReplyReplyKeyboardMarkup parent = null)
        {
            if (baseMenu == null) return;
            foreach (var keyboards in baseMenu.Keyboard)
            {
                foreach (var button in keyboards)
                {
                    if (button.ToBack)
                        button.Prev = parent;

                    SetPrev(button.Next, baseMenu);
                }
            }
        }

        public static CustomReplyReplyKeyboardMarkup GetStartMenu()
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
    }
}