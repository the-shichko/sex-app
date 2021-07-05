using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Models
{
    public class CustomKeyboardButton : KeyboardButton
    {
        public CustomKeyboardButton(string text, ReplyKeyboardMarkup next)
        {
            Id = Guid.NewGuid();
            Text = text;
        }

        public Guid Id { get; set; }
        public ReplyKeyboardMarkup Next { get; set; }
        public ReplyKeyboardMarkup Prev { get; set; }

        public ReplyKeyboardMarkup ClickText() => Next;
    }
}