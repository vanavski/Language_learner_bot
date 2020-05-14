﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Extensions.DependencyInjection;
using LanguageBot.DataBase;
using System;

namespace LanguageBot
{
    public class GameToCommand : Command
    {
        public override string PreviousCommand => "game";

        public override string CommandName => "to";


        public override bool CanUse(long chatId, Message message)
        {
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(chatId);
            return user.PreviousCommand == PreviousCommand;
        }
        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}