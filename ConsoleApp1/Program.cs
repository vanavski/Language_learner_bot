using LanguageBot;
using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using Telegram.Bot.Args;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartUp.Start();
            var client = Bot.Get();
            client.Timeout = TimeSpan.FromSeconds(10);
            var info = client.GetMeAsync().Result;
            Console.WriteLine(info.Id + " " + info.FirstName);
            client.OnUpdate += Bot_OnUpdate;
            client.StartReceiving();

            Console.ReadLine();
        }

        private static void Bot_OnUpdate(object sender, UpdateEventArgs e)
        {
            UpdateHandler.OnUpdate(e.Update);
        }
    }
}
