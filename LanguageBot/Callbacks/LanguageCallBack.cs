using LanguageBot.DataBase;
using LanguageBot.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class LanguageCallBack : CallBackCommand
    {
        public override string Name => "chosenLang";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<UsersRepository>();
            var user = repo.Get(userId);
            return user != null && callback.Data.StartsWith(Name);
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []
                    {
                        InlineKeyboardButton.WithCallbackData("Перейти в меню","menu")}
                });

        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<UsersRepository>();
            var user = repo.Get(callback.From.Id);
            var lng = callback.Data.Split(":")[1];
            user.PreviousCommand = "chosenLang";
            user.Language = lng;
            repo.Update(user);
            client.EditMessageTextAsync(chatId: callback.From.Id, messageId: callback.Message.MessageId, text: "Вы успешно зарегистрировались!", replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
