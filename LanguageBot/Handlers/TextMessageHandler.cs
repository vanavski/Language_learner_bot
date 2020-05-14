using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Types;

namespace LanguageBot
{
    public static class TextMessageHandler
    {
        public static async void OnMessageAsync(Message message) 
        {
            if (Bot.Commands.FirstOrDefault(x => x.CommandName == message.Text).CanUse(message.Chat.Id,message))
            {
                var cmd = Bot.Commands.FirstOrDefault(x => x.CommandName == message.Text);
                await cmd.ExecuteAsync(message, Bot.Get());
            }
            else 
            {
                //some todo
            }
        }
    }
}
