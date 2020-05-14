using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LanguageBot
{
    public static class UpdateHandler
    {
        public static void OnUpdate(Update update) 
        {
            switch (update.Type) 
            {
                case UpdateType.CallbackQuery:
                    CallbackHandler.OnCallBack(update.CallbackQuery);
                    return;
                case UpdateType.Message:
                    MessageHandler.OnMessage(update.Message);
                    return;
            }
        }
    }
}
