using LanguageBot.DataBase;
using LanguageBot.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            var repo = Depends.Provider.GetService<UsersRepository>();
            var user = repo.Get(userId);
            return user != null && (callback.Data.StartsWith(Name) || callback.Data.EndsWith(Name));
        }

        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
              {
              new []{
                InlineKeyboardButton.WithCallbackData("За сутки","statistics:day") },
              new []{
                InlineKeyboardButton.WithCallbackData("За неделю","statistics:week") },
              new []{
                InlineKeyboardButton.WithCallbackData("За месяц","statistics:month") },
              new []{
                InlineKeyboardButton.WithCallbackData("За все время", "statistics:all")},
              new []{
                InlineKeyboardButton.WithCallbackData("« Меню","menu")}
                });
        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var usRepo = Depends.Provider.GetService<UsersRepository>();
            var stRepo = Depends.Provider.GetService<StatisticsRepository>();
            var user = usRepo.Get(callback.From.Id);
            user.PreviousCommand = "stat";
            usRepo.Update(user);

            if (callback.Data.StartsWith(Name))
            {
                var period = callback.Data.Split(":")[1];
                var postfix = "";
                switch (period)
                {
                    case "day":
                        postfix = "сутки";
                        break;
                    case "week":
                        postfix = "неделю";
                        break;
                    case "month":
                        postfix = "месяц";
                        break;
                    case "all":
                        postfix = "все время";
                        break;
                }
                var st = stRepo.Get(period, user.Id);
                client.EditMessageTextAsync(chatId: callback.From.Id, messageId: callback.Message.MessageId, text: "Статистика ответов за " + postfix + ":\nПравильных - " + st.Item1 + "\nНеправильных - " + st.Item2, replyMarkup: inlineKeyboard);
            }
            else
                client.EditMessageTextAsync(chatId: callback.From.Id, messageId: callback.Message.MessageId, text: "Выберите период:", replyMarkup: inlineKeyboard);

            return Task.CompletedTask;
        }
    }
}
