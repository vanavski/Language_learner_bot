using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class GameCallBack : CallBackCommand
    {
        public override string Name => "game";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(userId);
            return user != null && callback.Data.EndsWith(Name);
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []{
                    InlineKeyboardButton.WithCallbackData("С русского на выбранный","game:to"),
                    InlineKeyboardButton.WithCallbackData("С выбранного на русский","game:from")},
                new []{
                        InlineKeyboardButton.WithCallbackData("« Меню","menu")}
                });
        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(callback.From.Id);
            user.PreviousCommand = "game";
            repo.UpdateUser(user);
            client.SendTextMessageAsync(chatId: callback.From.Id, text: "Выберите режим перевода:", replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
