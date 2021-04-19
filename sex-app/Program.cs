using System;
using System.Threading.Tasks;
using sex_app.Service;

namespace sex_app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bot = new TelegramService();
            bot.Start();

            Console.WriteLine("Working...");
            await Task.Delay(-1);
        }
    }
}