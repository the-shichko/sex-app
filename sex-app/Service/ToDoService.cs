using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Models;
using Telegram.Bot.Types;

namespace sex_app.Service
{
    public class ToDoService
    {
        private UserService _userService;

        public ToDoService(UserService userService)
        {
            _userService = userService;
        }

        public async Task AddToDo(Message message, string[] paramList)
        {
            
        }
    }
}