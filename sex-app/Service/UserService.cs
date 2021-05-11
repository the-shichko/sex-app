using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sex_app.Exception;
using sex_app.Models;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace sex_app.Service
{
    public class UserService
    {
        public UserService()
        {
            var (users, couples) = GetSessionData().GetAwaiter().GetResult();

            ApplicationCouples = couples;
            ApplicationUsers = users;
        }

        public ApplicationUsers ApplicationUsers { get; }
        public ApplicationCouples ApplicationCouples { get; }

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
                    UserName = userChat.Username ?? userChat.FirstName
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
            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\users.json", jsonUsers);

            var jsonCouples = JsonConvert.SerializeObject(ApplicationCouples);
            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\couples.json", jsonCouples);
        }

        private static async Task<(ApplicationUsers, ApplicationCouples)> GetSessionData()
        {
            var users = File.Exists($"{Directory.GetCurrentDirectory()}\\users.json")
                ? JsonConvert.DeserializeObject<ApplicationUsers>(
                    await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}\\users.json"))
                : new ApplicationUsers();

            var couples = File.Exists($"{Directory.GetCurrentDirectory()}\\couples.json")
                ? JsonConvert.DeserializeObject<ApplicationCouples>(
                    await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}\\couples.json"))
                : new ApplicationCouples();
            return (users, couples);
        }
    }
}