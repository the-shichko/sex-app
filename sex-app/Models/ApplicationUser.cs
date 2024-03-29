﻿using System.Collections.Generic;
using System.Linq;
using sex_app.Enums;

namespace sex_app.Models
{
    public class ApplicationUsers : List<ApplicationUser>
    {
        public ApplicationUsers()
        {
        }

        public ApplicationUsers(params ApplicationUser[] users)
        {
            AddRange(users);
        }

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
        public string CurrentMenuTitle { get; set; }
        public string Photo { get; set; }
        public StatusUser StatusUser { get; set; } = StatusUser.Default;
    }

    public enum Gender
    {
        Male,
        Female
    }
}