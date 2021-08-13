using System;
using System.Collections.Generic;
using System.Linq;
using sex_app.Extensions;
using sex_app.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Service
{
    public static class MenuService
    {
        private static CustomReplyKeyboardMarkup MainMenu { get; set; }

        private const string HomeEmoji = "🏠";
        private const string BackText = "⬅️";

        public static void Init()
        {
            MainMenu = new CustomReplyKeyboardMarkup
            {
                Title = HomeEmoji,
                Keyboard = new IEnumerable<CustomKeyboardButton>[]
                {
                    new CustomKeyboardButton[]
                    {
                        new("💕", new CustomReplyKeyboardMarkup
                        {
                            Title = "💕",
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("Позы 🔥", new CustomReplyKeyboardMarkup
                                    {
                                        Title = "Позы 🔥",
                                        Keyboard = new IEnumerable<CustomKeyboardButton>[]
                                        {
                                            new CustomKeyboardButton[]
                                            {
                                                new("/category"),
                                                new("/location"),
                                                new("/eye"),
                                                new("/activity"),
                                            },
                                            new CustomKeyboardButton[]
                                            {
                                                new("/stimulation"),
                                                new("/penetration"),
                                                new("/caress"),
                                                new(BackText, true)
                                            }
                                        }
                                    }),
                                    new("Купоны 🎫"),
                                    new("/random")
                                },
                                new CustomKeyboardButton[] { new(BackText, true) }
                            }
                        }),
                        new("info", new CustomReplyKeyboardMarkup
                        {
                            Title = "Info",
                            Keyboard = new IEnumerable<CustomKeyboardButton>[]
                            {
                                new CustomKeyboardButton[]
                                {
                                    new("/coupleInfo"),
                                    new(BackText, true),
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

        private static void SetPrev(CustomReplyKeyboardMarkup baseMenu,
            CustomReplyKeyboardMarkup parent = null)
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

        public static CustomReplyKeyboardMarkup GetByTitle(string title, CustomReplyKeyboardMarkup baseMenu)
        {
            if (baseMenu == null)
                return null;
            if (baseMenu.Title == title)
                return baseMenu;

            return (from keyboards in baseMenu.Keyboard
                    from button in keyboards
                    select GetByTitle(title, button.Next))
                .FirstOrDefault();
        }

        public static CustomReplyKeyboardMarkup GetStartMenu()
        {
            return MainMenu;
        }

        public static string GetPath(CustomReplyKeyboardMarkup currentMenu)
        {
            if (currentMenu == null)
                return null;
            foreach (var keyboards in currentMenu.Keyboard)
            {
                foreach (var button in keyboards)
                {
                    if (button.ToBack)
                        return $"{GetPath(button.Prev)} - {currentMenu.Title}";
                }
            }

            return MainMenu.Title;
        }

        public static IReplyMarkup GetReplyEnum(Type type)
        {
            if (!type.IsEnum) return null;

            var items = (from object item in Enum.GetValues(type) select item).ToList();

            var inlineButtons = new List<List<InlineKeyboardButton>>();
            const int columns = 2;
            for (var i = 0; i < items.Count; i += columns)
            {
                inlineButtons.Add(
                    items.Skip(i).Take(columns).Select(x =>
                        new InlineKeyboardButton
                        {
                            Text = x.GetDisplayName(),
                            CallbackData = $"{type}&{x}"
                        }).ToList());
            }

            return new InlineKeyboardMarkup(inlineButtons);
        }
    }
}