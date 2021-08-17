using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Service
{
    public static class ReplyMarkupService
    {
        public static CustomInlineKeyboardMarkup MenuMarkup { get; } = new(
            new List<List<CustomInlineKeyboardButton>>
            {
                new()
                {
                    new CustomInlineKeyboardButton("Категории поз")
                    {
                        CallbackData = "Menu-Category",
                        NextMarkup = new CustomInlineKeyboardMarkup(
                            new List<List<CustomInlineKeyboardButton>>
                            {
                                new()
                                {
                                    new CustomInlineKeyboardButton("Категория")
                                    {
                                        CallbackData = "Enums.Category"
                                    },
                                    new CustomInlineKeyboardButton("Положение")
                                    {
                                        CallbackData = "Enums.Location"
                                    },
                                },
                                new()
                                {
                                    new CustomInlineKeyboardButton("Стимулирование")
                                    {
                                        CallbackData = "Enums.Stimulation"
                                    },
                                    new CustomInlineKeyboardButton("Проникновение")
                                    {
                                        CallbackData = "Enums.LevelPenetration"
                                    },
                                },
                                new()
                                {
                                    new CustomInlineKeyboardButton("Активность")
                                    {
                                        CallbackData = "Enums.Activity"
                                    },
                                    new CustomInlineKeyboardButton("Зрит. контакт")
                                    {
                                        CallbackData = "Enums.BaseBool"
                                    },
                                },
                                new()
                                {
                                    new CustomInlineKeyboardButton("Уровень")
                                    {
                                        CallbackData = "Enums.Level"
                                    },
                                    new CustomInlineKeyboardButton("Доп. ласки")
                                    {
                                        CallbackData = "Enums.AdditionalCaress"
                                    },
                                },
                                new()
                                {
                                    new CustomInlineKeyboardButton("Назад в меню")
                                    {
                                        CallbackData = "Back-Menu", IsBack = true
                                    },
                                }
                            }, "Выберите пункт для подбора позы")
                    }
                },
                new()
                {
                    new CustomInlineKeyboardButton("Подборка")
                    {
                        CallbackData = "Menu-Sex"
                    },
                }
            }, "Выберите пункт меню");

        public static void Init()
        {
            SetEnumsReply();
            SetPrev(MenuMarkup);
        }

        private static void SetPrev(CustomInlineKeyboardMarkup baseMenu,
            CustomInlineKeyboardMarkup parent = null)
        {
            if (baseMenu == null) return;
            foreach (var keyboards in baseMenu.InlineKeyboard)
            {
                foreach (var button in (IEnumerable<CustomInlineKeyboardButton>)keyboards)
                {
                    if (button.IsBack)
                        button.PrevMarkup = parent;

                    SetPrev(button.NextMarkup, baseMenu);
                }
            }
        }

        private static void SetEnumsReply()
        {
            FindReplyButtonByData("Enums.Category").NextMarkup = GetReplyEnum(typeof(Category));
            FindReplyButtonByData("Enums.Location").NextMarkup = GetReplyEnum(typeof(Location));
            FindReplyButtonByData("Enums.Stimulation").NextMarkup = GetReplyEnum(typeof(Stimulation));
            FindReplyButtonByData("Enums.LevelPenetration").NextMarkup = GetReplyEnum(typeof(LevelPenetration));
            FindReplyButtonByData("Enums.AdditionalCaress").NextMarkup = GetReplyEnum(typeof(AdditionalCaress));
            FindReplyButtonByData("Enums.Activity").NextMarkup = GetReplyEnum(typeof(Activity));
            FindReplyButtonByData("Enums.BaseBool").NextMarkup = GetReplyEnum(typeof(BaseBool));
            FindReplyButtonByData("Enums.Level").NextMarkup = GetReplyEnum(typeof(Level));
        }

        private static CustomInlineKeyboardButton FindReplyButtonByData(string callbackQueryData)
        {
            return GetReplyMarkupByData(callbackQueryData, MenuMarkup, true).Item2;
        }

        public static CustomInlineKeyboardMarkup GetReplyMarkupByData(string callbackQueryData)
        {
            return GetReplyMarkupByData(callbackQueryData, MenuMarkup).Item1;
        }

        private static (CustomInlineKeyboardMarkup, CustomInlineKeyboardButton) GetReplyMarkupByData(
            string callbackQueryData, InlineKeyboardMarkup baseMenu, bool findButton = false)
        {
            if (baseMenu == null)
                return (null, null);

            foreach (var enumerable in baseMenu.InlineKeyboard)
            {
                var inlineKeyboardButtonsList = ((IEnumerable<CustomInlineKeyboardButton>)enumerable).ToList();
                foreach (var button in inlineKeyboardButtonsList)
                {
                    if (button.CallbackData == callbackQueryData)
                        return (!button.IsBack ? button.NextMarkup : button.PrevMarkup, button);

                    var (next, currentButton) = GetReplyMarkupByData(callbackQueryData, button.NextMarkup);
                    if (next != null || findButton)
                        return (next, currentButton);
                }
            }

            return (null, null);
        }

        private static CustomInlineKeyboardMarkup GetReplyEnum(Type type)
        {
            if (!type.IsEnum) return null;

            var items = (from object item in Enum.GetValues(type) select item).ToList();

            var inlineButtons = new List<List<CustomInlineKeyboardButton>>();
            const int columns = 2;
            for (var i = 0; i < items.Count; i += columns)
            {
                inlineButtons.Add(
                    items.Skip(i).Take(columns).Select(x =>
                        new CustomInlineKeyboardButton(x.GetDisplayName())
                        {
                            CallbackData = $"{type}&{x}"
                        }).ToList());
            }

            inlineButtons.Add(new List<CustomInlineKeyboardButton>()
            {
                new("Назад к категориям") { IsBack = true, CallbackData = "BackCategory" },
            });

            return new CustomInlineKeyboardMarkup(inlineButtons, "Выберите из списка значение для подбора позы)");
        }
    }

    public class CustomInlineKeyboardButton : InlineKeyboardButton
    {
        public CustomInlineKeyboardMarkup NextMarkup { get; set; }
        public CustomInlineKeyboardMarkup PrevMarkup { get; set; }
        public bool IsBack { get; set; }

        public CustomInlineKeyboardButton(string text) : base(text)
        {
        }
    }

    public class CustomInlineKeyboardMarkup : InlineKeyboardMarkup
    {
        public string MessageText { get; }

        public CustomInlineKeyboardMarkup(InlineKeyboardButton inlineKeyboardButton, string messageText) : base(
            inlineKeyboardButton)
        {
            MessageText = messageText;
        }

        public CustomInlineKeyboardMarkup(IEnumerable<InlineKeyboardButton> inlineKeyboardRow, string messageText) :
            base(inlineKeyboardRow)
        {
            MessageText = messageText;
        }

        public CustomInlineKeyboardMarkup(IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboard,
            string messageText) : base(
            inlineKeyboard)
        {
            MessageText = messageText;
        }

        public async Task Send(long chatId, ITelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(chatId, MessageText, replyMarkup: this);
        }
    }
}