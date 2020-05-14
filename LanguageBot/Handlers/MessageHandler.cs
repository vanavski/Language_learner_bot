using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LanguageBot
{
    public static class MessageHandler
    {
        public static void OnMessage(Message message) 
        {
            switch (message.Type) 
            {
                case MessageType.Text:
                    TextMessageHandler.OnMessageAsync(message);
                    return;                
            }
        }
    }
}
