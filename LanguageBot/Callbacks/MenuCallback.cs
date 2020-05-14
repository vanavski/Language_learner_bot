using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
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
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(userId);
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
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(callback.From.Id);
            user.PreviousCommand = "menu";
            repo.UpdateUser(user);

            if (callback.Data.EndsWith("stat"))
                Bot.CallBackCommands[2].ExecuteAsync(callback, client);
            else if (callback.Data.EndsWith("game"))
                Bot.CallBackCommands[3].ExecuteAsync(callback, client);
            else 
                client.SendTextMessageAsync(chatId: callback.From.Id, text: "Меню:", replyMarkup: inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
