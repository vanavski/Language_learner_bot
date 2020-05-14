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
    public class MenuCommand : Command
    {
        public override string PreviousCommand => "";

        public override string CommandName => "menu";

        public override bool CanUse(long chatId, Message message)
        {
            return true;
        }

        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
