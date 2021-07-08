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
                        new("sex", new CustomReplyReplyKeyboardMarkup
                        {
                            Title = "Sex",
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("categories", new CustomReplyReplyKeyboardMarkup
                                    {
                                        Title = "Categories",
                                        Keyboard = new IEnumerable<CustomKeyboardButton>[]
                                        {
                                            new CustomKeyboardButton[]
                                            {
                                                new("/cunnilingus"),
                                                new ("назад", true)
                                            }
                                        }
                                    }),
                                    new("/fullRandom"),
                                },
                                new CustomKeyboardButton[]
                                {
                                    new ("назад", true)
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
    }
}