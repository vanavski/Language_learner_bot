using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Extensions.DependencyInjection;
using LanguageBot.DataBase;

namespace LanguageBot
{
    public class StatisticCommand : Command
    {
        public override string PreviousCommand => "/ChosseLang";

        public override string CommandName => "/Static";


        public override bool CanUse(long chatId,Message message)
        {
            var repo = Depends.Provider.GetService<UserRepository>();
            var user = repo.GetUserById(chatId);
            return user.PreviousCommand == PreviousCommand;
        }
        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            //db statisticget and send client; 
            client.SendTextMessageAsync(chatId: message.Chat.Id, text: "Db int");           
            return Task.CompletedTask;
        }
    }
}
