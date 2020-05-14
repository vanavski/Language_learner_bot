using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class StatisticsCallBack : CallBackCommand
    {
        public override string Name => "stat";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(userId);
            return user != null && callback.Data.EndsWith(Name);
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []
                    {
                        InlineKeyboardButton.WithCallbackData("Меню","menu")}
                });
        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(callback.From.Id);
            user.PreviousCommand = "stat";
            repo.UpdateUser(user);
            client.SendTextMessageAsync(chatId: callback.From.Id, text: "Статистика ответов:\nПравильных - " + user.RightAnsw + "\nНеправильных - "+ user.WrongAnsw, replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
