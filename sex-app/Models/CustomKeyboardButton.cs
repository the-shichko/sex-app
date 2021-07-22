using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Models
{
    public class CustomReplyKeyboardMarkup : ReplyMarkupBase
    {
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<IEnumerable<CustomKeyboardButton>> Keyboard { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ResizeKeyboard { get; set; } = true;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool OneTimeKeyboard { get; set; }
        
        public string Title { get; set; }

        public CustomReplyKeyboardMarkup()
        {
        }

        public CustomReplyKeyboardMarkup(CustomKeyboardButton button)
            : this(new[] {button})
        {
        }

        public CustomReplyKeyboardMarkup(IEnumerable<CustomKeyboardButton> keyboardRow,
            bool resizeKeyboard = default,
            bool oneTimeKeyboard = default)
            : this(new[] {keyboardRow}, resizeKeyboard, oneTimeKeyboard)
        {
        }

        public CustomReplyKeyboardMarkup(IEnumerable<IEnumerable<CustomKeyboardButton>> keyboard,
            bool resizeKeyboard = default,
            bool oneTimeKeyboard = default)
        {
            Keyboard = keyboard;
            ResizeKeyboard = resizeKeyboard;
            OneTimeKeyboard = oneTimeKeyboard;
        }

        public static implicit operator CustomReplyKeyboardMarkup(string text) =>
            text == null
                ? default
                : new CustomReplyKeyboardMarkup(new[] {new CustomKeyboardButton(text)});

        public static implicit operator CustomReplyKeyboardMarkup(string[] texts) =>
            texts == null
                ? default
                : new[] {texts};

        public static implicit operator CustomReplyKeyboardMarkup(string[][] textsItems) =>
            textsItems == null
                ? default
                : new CustomReplyKeyboardMarkup(
                    textsItems.Select(texts =>
                        texts.Select(t => new CustomKeyboardButton(t))
                    ));
    }

    public class CustomKeyboardButton : KeyboardButton
    {
        public CustomKeyboardButton(string text, CustomReplyKeyboardMarkup next) : base(text)
        {
            Next = next;
        }

        public CustomKeyboardButton(string text, bool toBack = false) : base(text)
        {
            ToBack = toBack;
        }

        public CustomKeyboardButton()
        {
        }

        public CustomReplyKeyboardMarkup Next { get; set; }
        public CustomReplyKeyboardMarkup Prev { get; set; }
        public bool ToBack { get; set; }

        public CustomReplyKeyboardMarkup Click() => ToBack ? Prev : Next;
    }
}