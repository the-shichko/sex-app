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

            // foreach (var keyboads in baseMenu.Keyboard)
            // {
            // }

            return (from keyboards in baseMenu.Keyboard from button in keyboards select GetByTitle(title, button.Next))
                .FirstOrDefault(markup => markup != null);
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

        
    }
}