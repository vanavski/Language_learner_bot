using LanguageBot.DataBase;
using LanguageBot.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class MaterialsCallback : CallBackCommand
    {
        public override string Name => "mat";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<UsersRepository>();
            var user = repo.Get(userId);
            return user != null && callback.Data.EndsWith(Name);
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {
                new []{
                    InlineKeyboardButton.WithCallbackData("« Меню","menu")}
                });
        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<UsersRepository>();
            var matRepo = Depends.Provider.GetService<TopicsRepository>();
            var user = repo.Get(callback.From.Id);
            user.PreviousCommand = "mat";
            repo.Update(user);

            var dict = matRepo.Get(user.Language.ToString());

            var tex = "";
            var i = 0;
            foreach (var item in dict)
            {
                if (i < 10)
                {
                    tex += item.Key + "\n" + item.Value + "\n" + "\n";
                    i++;
                }
            }

            client.EditMessageTextAsync(chatId: callback.From.Id, messageId: callback.Message.MessageId, text: tex, replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
