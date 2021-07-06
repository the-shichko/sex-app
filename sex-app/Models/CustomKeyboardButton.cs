using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Models
{
    public class CustomReplyReplyKeyboardMarkup : ReplyMarkupBase
    {
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<IEnumerable<CustomKeyboardButton>> Keyboard { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ResizeKeyboard { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool OneTimeKeyboard { get; set; }

        public CustomReplyReplyKeyboardMarkup()
        {
        }

        public CustomReplyReplyKeyboardMarkup(CustomKeyboardButton button)
            : this(new[] {button})
        {
        }

        public CustomReplyReplyKeyboardMarkup(IEnumerable<CustomKeyboardButton> keyboardRow,
            bool resizeKeyboard = default,
            bool oneTimeKeyboard = default)
            : this(new[] {keyboardRow}, resizeKeyboard, oneTimeKeyboard)
        {
        }

        public CustomReplyReplyKeyboardMarkup(IEnumerable<IEnumerable<CustomKeyboardButton>> keyboard,
            bool resizeKeyboard = default,
            bool oneTimeKeyboard = default)
        {
            Keyboard = keyboard;
            ResizeKeyboard = resizeKeyboard;
            OneTimeKeyboard = oneTimeKeyboard;
        }

        public static implicit operator CustomReplyReplyKeyboardMarkup(string text) =>
            text == null
                ? default
                : new CustomReplyReplyKeyboardMarkup(new[] {new CustomKeyboardButton(text)});

        public static implicit operator CustomReplyReplyKeyboardMarkup(string[] texts) =>
            texts == null
                ? default
                : new[] {texts};

        public static implicit operator CustomReplyReplyKeyboardMarkup(string[][] textsItems) =>
            textsItems == null
                ? default
                : new CustomReplyReplyKeyboardMarkup(
                    textsItems.Select(texts =>
                        texts.Select(t => new CustomKeyboardButton(t))
                    ));
    }

    public class CustomKeyboardButton : KeyboardButton
    {
        public CustomKeyboardButton(string text, CustomReplyReplyKeyboardMarkup next) : base(text)
        {
            Id = Guid.NewGuid();
            Next = next;
        }

        public CustomKeyboardButton(string text, bool toBack = false) : base(text)
        {
            Id = Guid.NewGuid();
            ToBack = toBack;
        }

        public CustomKeyboardButton()
        {
        }

        public Guid Id { get; set; }
        public CustomReplyReplyKeyboardMarkup Next { get; set; }
        public CustomReplyReplyKeyboardMarkup Prev { get; set; }
        public bool ToBack { get; set; }

        public CustomReplyReplyKeyboardMarkup Click() => ToBack ? Prev : Next;
    }
}