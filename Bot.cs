using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;

namespace LanguageBot
{
    public class Bot
    {
        //Api бота
        private const string token = "1145240060:AAGBCPgnDnBHNjgRAo3SdobV2CJxpg7zd1U";
        public TelegramBotClient Client;

        public Bot()
        {
        }

        //запуск бота
        public void TestApiAsync()
        {
            try
            {
                Client = new TelegramBotClient(token);

                Thread newThread = new Thread(ReceiveMessage);
                newThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //обработка сообщений пользователя
        private async void ReceiveMessage()
        {
            Console.WriteLine(
              $"Бот успешно запущен!"
            );

            var lastMessageId = 0;

            while (true)
            {
                var messages = await Client.GetUpdatesAsync();
                if (messages.Length > 0)
                {
                    var last = messages[messages.Length - 1];
                    if (lastMessageId != last.Id && last.Message != null)
                    {
                        var rkm = new ReplyKeyboardMarkup();
                        rkm.ResizeKeyboard = true;
                        //выпадают на выбор смайл, отвечающий за некоторый запрос
                        rkm.Keyboard = new KeyboardButton[][]
                        {
                            new KeyboardButton[]
                            {
                                new KeyboardButton("🥫")     //Обосраться
                            }
                        };

                        lastMessageId = last.Id;
                        Console.WriteLine(last.Message.Text);
                        string message = AnalyzeQuery(last);

                        await Client.SendTextMessageAsync(last.Message.From.Id, message, replyMarkup: rkm);
                    }
                }
                Thread.Sleep(100);
            }
        }

        //обработка запросов
        private string AnalyzeQuery(Update update)
        {
            var query = update.Message.Text;
            var                    //стартовая команда при запуске бота
                    message = query switch
                    {
                        "/start" => CommandStart(update),

                        "🥫" => CommandPoop(update),

                        //команды, вводимые пользователем самостоятельно
                        _ => "Неизвестная команда",
                    };
            return message;
        }

        //стартовая команда
        private string CommandStart(Update update)
        {
            Registration(update);

            return "Здравствуйте! Я — бот для изучения языков. Вы успешно зарегистровались! \nИспользуйте команды для продолжения:\n \n" +
                "🥫 - тестовая кнопка\n";
        }

        //регистрация
        private void Registration(Update update)
        {
            
        }

        private string CommandPoop(Update update)
        {
            string message = "🥫🥫🥫Нажатие обработано!🥫🥫🥫\n";

            return message;
        }

    }
}