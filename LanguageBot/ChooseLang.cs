using LanguageBot.DataBase;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageBot
{
    public class ChooseLang : Command
    {
        public override string PreviousCommand => "/start";

        public override string CommandName => "chosenLang";

        public override bool CanUse(long chatId,Message message)
        {
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(chatId);
            return user.PreviousCommand == PreviousCommand;
        }

        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
