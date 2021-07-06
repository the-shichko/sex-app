using System.Collections.Generic;
using System.Linq;
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
                Title = "Main",
                Keyboard = new IEnumerable<CustomKeyboardButton>[]
                {
                    new CustomKeyboardButton[]
                    {
                        new("partner", new CustomReplyReplyKeyboardMarkup
                        {
                            Title = "Partner",
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("/hello"),
                                    new("назад", true)
                                }
                            }
                        }),
                        new("info", new CustomReplyReplyKeyboardMarkup
                        {
                            Title = "Info",
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("/coupleInfo"),
                                    new("назад", true),
                                }
                            },
                            ResizeKeyboard = true
                        }),
                    }
                },
                ResizeKeyboard = true
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

        public static string GetPath(CustomReplyReplyKeyboardMarkup currentMenu)
        {
            if (currentMenu == null)
                return null;
            foreach (var keyboards in currentMenu.Keyboard)
            {
                foreach (var button in keyboards)
                {
                    if (button.ToBack)
                        return $"{GetPath(button.Prev)} > {currentMenu.Title}";
                }
            }

            return "Main";
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