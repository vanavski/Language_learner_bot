using LanguageBot.Database;
using MySql.Data.MySqlClient;
using Npgsql;
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
            Console.WriteLine("Getting Connection ...");
            NpgsqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}