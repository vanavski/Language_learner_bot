using LanguageBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.Extensions.DependencyInjection;


namespace LanguageBot
{
    public class StartCommand : Command
    {
        public override string PreviousCommand => "";

        public override string CommandName => "/start";

        public override bool CanUse(long chatId, Message message)
        {
            return true;
        }


        private static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
               {new []
                    {
                        InlineKeyboardButton.WithCallbackData("English","chosenLang:Eng")} ,new[]{
                        InlineKeyboardButton.WithCallbackData("Немейский","chosenLang:Nem")} ,new[]{
                        InlineKeyboardButton.WithCallbackData("Китайкий","chosenLang:Chn")}});
        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            var repo=Depends.Provider.GetService<Repository>();
            var user = new User()
            {
                Id = message.From.Id,
                Name = message.From.FirstName,
                PreviousCommand = "/start"
            };
            repo.AddUser(user);
            client.SendTextMessageAsync(message.Chat.Id,"ChooseLang",replyMarkup:inlineKeyboard);
            return Task.CompletedTask;
        }
    }
}
