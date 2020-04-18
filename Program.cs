using System;

namespace LanguageBot
{
    class Program
    {
        // единую базу на хостинг
        //Никита: связать логикой от выбора языка до игры, слова брать из локального файла в папке бд
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