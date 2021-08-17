using System;
using System.Threading.Tasks;
using sex_app.Service;

namespace sex_app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            _ = new TelegramService();
            await Task.Delay(-1);
        }
    }
}