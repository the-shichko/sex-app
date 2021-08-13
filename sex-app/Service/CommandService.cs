using System;
using System.Linq;
using System.Threading.Tasks;
using sex_app.Enums;
using sex_app.Exceptions;
using sex_app.Extensions;
using sex_app.Models;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Location = sex_app.Enums.Location;

namespace sex_app.Service
{
    public class CommandService : BotExecuteService<MessageEventArgs>
    {
        private static readonly ListCommands<MessageEventArgs, string[], Task> BotCommands = new();
        private static readonly UserService UserService = new();

        public CommandService(MyTelegramBotClient botClient) : base(botClient)
        {
            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    var chatId = e.Message.Chat.Id;
                    await UserService.AddUser(e.Message.Chat);

                    // await BotClient.SendTextMessageAsync(chatId, "Выбери пол", replyMarkup: MenuService.GetSelectGender());
                    await BotClient.SendTextMessageAsync(chatId, $"Здравствуй, *{e.Message.Chat.Username}*\n" +
                                                                 $"Отправь своей половинке этот код:",
                        ParseMode.Markdown);
                    await BotClient.SendTextMessageAsync(chatId, $"/couple *{chatId}*", ParseMode.Markdown);
                }, "/start"));


            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, paramList) =>
            {
                var chatId = e.Message.Chat.Id;
                if (paramList.Length == 0 || !long.TryParse(paramList[0], out var id)) return;

                var (coupleId, result) = await UserService.AddCouple(chatId, id);
                switch (result)
                {
                    case CoupleResult.CoupleExist:
                        var users = UserService.GetUsersByCoupleId(coupleId.Value);
                        await BotClient.SendTextMessageAsync(chatId, "Пара уже добавлена.\n" +
                                                                     $"‣ *{users[0].UserName}*\n" +
                                                                     $"‣ *{users[1].UserName}*", ParseMode.Markdown);
                        break;
                    case CoupleResult.FirstUserNull:
                        await BotClient.SendTextMessageAsync(chatId, "Войдите в систему (/start)\n");
                        break;
                    case CoupleResult.SecondUserNull:
                        await BotClient.SendTextMessageAsync(chatId, "Пользователь не существует\n");
                        break;
                    case CoupleResult.Ok:
                        var usersOk = UserService.GetUsersByCoupleId(coupleId.Value);

                        await BotClient.SendTextMessageAsync(usersOk.Select(x => x.Id), "Добавлена пара:\n" +
                            $"‣ *{usersOk[0].UserName}*\n" +
                            $"‣ *{usersOk[1].UserName}*", ParseMode.Markdown, replyMarkup: MenuService.GetStartMenu());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }, "/couple"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(async (e, _) =>
            {
                var chatId = e.Message.Chat.Id;
                var couple = UserService.GetCouple(chatId);

                if (couple != null)
                    await BotClient.SendTextMessageAsync(chatId,
                        $"About: \n{couple.First().UserName} & {couple.Last().UserName} ❤");
            }, "/coupleInfo"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    var (message, mediaPath) = SexService.GetRandomPositionNew();
                    await BotClient.SendPhotoAsync(e.Message.Chat.Id, message, mediaPath);
                }, "/random"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите уровень",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Level)));
                }, "/level"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите положение",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Location)));
                }, "/location"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите категорию",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Category)));
                }, "/category"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите стимуляцию",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Stimulation)));
                }, "/stimulation"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите проникновение",
                        replyMarkup: MenuService.GetReplyEnum(typeof(LevelPenetration)));
                }, "/penetration"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Зрительный контакт",
                        replyMarkup: MenuService.GetReplyEnum(typeof(BaseBool)));
                }, "/eye"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите",
                        replyMarkup: MenuService.GetReplyEnum(typeof(AdditionalCaress)));
                }, "/caress"));

            BotCommands.Add(new BotCommand<MessageEventArgs, string[], Task>(
                async (e, _) =>
                {
                    await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Выберите активность",
                        replyMarkup: MenuService.GetReplyEnum(typeof(Activity)));
                }, "/activity"));
        }

        public override Func<MessageEventArgs, MyTelegramBotClient, string[], Task> ExecuteAction { get; set; } =
            async (e, botClient, paramList) =>
            {
                if (paramList[0].Contains("/"))
                {
                    var commandModel = BotCommands[paramList[0]];
                    if (commandModel != null)
                        await commandModel.Execute(e, paramList.Skip(1).ToArray());
                }

                var (path, menuMarkup) = await UserService.GetMenuForUser(e.Message.Chat.Id, paramList.Join(" "));
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, path,
                    replyMarkup: menuMarkup);
            };
    }
}