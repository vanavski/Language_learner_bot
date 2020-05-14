﻿using LanguageBot.DataBase;
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
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(userId);
            return user != null && callback.Data.StartsWith(Name);
        }


        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []
                    {
                        InlineKeyboardButton.WithCallbackData("Igra","menu:igra")} ,new[]{
                        InlineKeyboardButton.WithCallbackData("Statistika","menu:statistika")}
                });

        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(callback.From.Id);
            var lng = callback.Data.Split(":")[1];
            user.PreviousCommand= "chosenLang";
            user.Language = lng;
            repo.UpdateUser(user);
            client.SendTextMessageAsync(chatId:callback.From.Id,text:"Choose comand",replyMarkup:inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
