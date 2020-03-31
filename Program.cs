using System;

namespace LanguageBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //инициализация бота
            Bot bot = new Bot();
            //запуск
            bot.TestApiAsync();
            Console.ReadLine();
        }
    }
}