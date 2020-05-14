using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Types;

namespace LanguageBot
{
    public static class CallbackHandler
    {
        public static void OnCallBack(CallbackQuery callbackQuery)
        {
            var cmd = Bot.CallBackCommands.FirstOrDefault(x => x.CanUse(callbackQuery.From.Id, callbackQuery));
            if (cmd != null) 
            {
                cmd.ExecuteAsync(callbackQuery, Bot.Get());
            }
        }
    }
}
