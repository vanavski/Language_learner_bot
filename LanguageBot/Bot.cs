﻿using MihaZupan;
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
                new StartCommand()
            };
            CallBackCommands = new List<CallBackCommand>()
            {
                new LanguageCallBack(),
                new MenuCallBack(),
                new StatisticsCallBack(),
                new GameCallBack(),
                new GameToCallBack(),
                new GameFromCallBack(),
                new TeacherCallback(),
                new MaterialsCallback()
            };
            var socks = new HttpToSocks5Proxy("185.10.57.107", 1234);
            return client= new TelegramBotClient("1145240060:AAGBCPgnDnBHNjgRAo3SdobV2CJxpg7zd1U",socks);
        }
    }
}
