using MihaZupan;
using System.Collections.Generic;
using Telegram.Bot;

namespace LanguageBot
{
    public static class Bot
    {
        private static TelegramBotClient client;

        public static List<CallBackCommand> CallBackCommands;

        public static List<Command> Commands;

        public static TelegramBotClient Get()
        {
            if (client != null)
            {
                return client;
            }
            Commands = new List<Command>() {
                new StartCommand(),
                new ChooseLang(),
                new StartCommand()
            };
            CallBackCommands = new List<CallBackCommand>()
            {
                new LanguageCallBack()
            };
            var socks = new HttpToSocks5Proxy("96.96.33.133",1080);
            return client= new TelegramBotClient("1145240060:AAGBCPgnDnBHNjgRAo3SdobV2CJxpg7zd1U",socks);
        }
    }
}
