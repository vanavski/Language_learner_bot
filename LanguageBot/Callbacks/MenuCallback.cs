using LanguageBot.DataBase;
using LanguageBot.DataBase.Repositories;
using LanguageBot.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class MenuCallBack : CallBackCommand
    {
        public override string Name => "menu";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<UsersRepository>();
            var user = repo.Get(userId);
            return user != null && callback.Data.StartsWith(Name);
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []
                    {
                        InlineKeyboardButton.WithCallbackData("Играть","menu:game")} ,new[]{
                        InlineKeyboardButton.WithCallbackData("Статистика","menu:stat")}
                });

        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var usRepo = Depends.Provider.GetService<UsersRepository>();
            var stRepo = Depends.Provider.GetService<StatisticsRepository>();
            var user = usRepo.Get(callback.From.Id);

            if (user.PreviousCommand == "to" || user.PreviousCommand == "from")
            {
                stRepo.Add(new Result()
                {
                    UserId = user.Id,
                    Date = DateTime.Now,
                    RightAnsw = user.RightAnsw,
                    WrongAnsw = user.WrongAnsw
                });

                user.RightAnsw = 0;
                user.WrongAnsw = 0;
            }

            user.PreviousCommand = "menu";
            usRepo.Update(user);


            if (callback.Data.EndsWith("stat"))
                Bot.CallBackCommands[2].ExecuteAsync(callback, client);
            else if (callback.Data.EndsWith("game"))
                Bot.CallBackCommands[3].ExecuteAsync(callback, client);
            else 
                client.EditMessageTextAsync(chatId: callback.From.Id, messageId: callback.Message.MessageId, text: "Меню:", replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
