using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;

namespace sex_app.Models
{
    public class ApplicationUsers : List<ApplicationUser>
    {
        public ApplicationUser this[long id]
        {
            get { return this.FirstOrDefault(x => x.Id == id); }
        }
    }

    public class ApplicationUser
    {
        /// <summary>
        /// Telegram chat Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Telegram userName of User
        /// </summary>
        public string UserName { get; set; }

        public string CustomName { get; set; }
        public Gender Gender { get; set; }
        public ReplyKeyboardMarkup CurrentMenu { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}