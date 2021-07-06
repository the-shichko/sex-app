using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sex_app.Exceptions;
using sex_app.Models;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace sex_app.Service
{
    public class UserService
    {
        private const string PathUsers = "Data\\users.json";
        private const string PathCouples = "Data\\couples.json";

        public UserService()
        {
            var (users, couples) = GetSessionData().GetAwaiter().GetResult();

            ApplicationCouples = couples;
            ApplicationUsers = users;
        }

        private ApplicationUsers ApplicationUsers { get; }
        private ApplicationCouples ApplicationCouples { get; }

        public async Task<(Guid?, CoupleResult)> AddCouple(long firstId, long secondId)
        {
            if (ApplicationUsers[firstId] == null || ApplicationUsers[secondId] == null)
                return (null, CoupleResult.UserNull);

            if (ApplicationCouples[firstId] != null || ApplicationCouples[secondId] != null)
                return (ApplicationCouples[firstId].Id, CoupleResult.CoupleExist);

            var couple = new ApplicationCouple
            {
                Id = Guid.NewGuid(),
                FirstPartner = firstId,
                SecondPartner = secondId
            };

            ApplicationCouples.Add(couple);
            await SaveSession();
            return (couple.Id, CoupleResult.Ok);
        }

        public async Task AddUser(Chat userChat)
        {
            if (ApplicationUsers[userChat.Id] == null)
            {
                ApplicationUsers.Add(new ApplicationUser
                {
                    Id = userChat.Id,
                    UserName = userChat.Username ?? userChat.FirstName,
                    CurrentMenu = MenuService.GetStartMenu()
                });
                await SaveSession();
            }
        }

        public List<ApplicationUser> GetUsersByCoupleId(Guid coupleId)
        {
            var couple = ApplicationCouples.FirstOrDefault(x => x.Id == coupleId);

            return new ApplicationUsers()
            {
                ApplicationUsers.FirstOrDefault(x => x.Id == couple?.FirstPartner),
                ApplicationUsers.FirstOrDefault(x => x.Id == couple?.SecondPartner)
            };
        }

        private async Task SaveSession()
        {
            var jsonUsers = JsonConvert.SerializeObject(ApplicationUsers);
            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\{PathUsers}", jsonUsers);

            var jsonCouples = JsonConvert.SerializeObject(ApplicationCouples);
            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\{PathCouples}", jsonCouples);
        }

        private static async Task<(ApplicationUsers, ApplicationCouples)> GetSessionData()
        {
            var users = JsonConvert.DeserializeObject<ApplicationUsers>(
                await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}\\{PathUsers}"));

            var couples = JsonConvert.DeserializeObject<ApplicationCouples>(
                await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}\\{PathCouples}"));

            return (users, couples);
        }


        public async Task<(string, CustomReplyReplyKeyboardMarkup)> GetMenuForUser(long chatId, string clickedText)
        {
            var replyReplyKeyboardMarkup = FindUserMenuRecursion(chatId, clickedText);
            ApplicationUsers[chatId].CurrentMenu = replyReplyKeyboardMarkup ?? ApplicationUsers[chatId].CurrentMenu;
            await SaveSession();
            return (MenuService.GetPath(ApplicationUsers[chatId].CurrentMenu), ApplicationUsers[chatId].CurrentMenu);
        }

        private CustomReplyReplyKeyboardMarkup FindUserMenuRecursion(long chatId, string clickedText)
        {
            var userKeyboardMarkup = ApplicationUsers[chatId].CurrentMenu;

            if (userKeyboardMarkup == null)
                return MenuService.GetStartMenu();

            return (from keyboardButtons in userKeyboardMarkup.Keyboard
                from keyboardButton in keyboardButtons
                where keyboardButton.Text == clickedText
                select keyboardButton.Click()).FirstOrDefault();
        }

        /// <summary>
        /// Get users in couple
        /// </summary>
        /// <param name="partnerId">Any partner's Id</param>
        /// <returns><see cref="ApplicationUsers"/></returns>
        public ApplicationUsers GetCouple(long partnerId)
        {
            var couple = ApplicationCouples[partnerId];

            return couple != null
                ? new ApplicationUsers(ApplicationUsers[couple.FirstPartner], ApplicationUsers[couple.SecondPartner])
                : null;
        }
    }
}