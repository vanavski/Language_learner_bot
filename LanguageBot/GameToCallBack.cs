using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageBot
{
    public class GameToCallBack : CallBackCommand
    {
        public override string Name => "to";

        public override bool CanUse(long userId, CallbackQuery callback)
        {
            var repo = Depends.Provider.GetService<Repository>();
            var user = repo.GetUserById(userId);
            return user != null && 
                (callback.Data.EndsWith(Name)
                || (callback.Data.StartsWith(Name) && callback.Data.EndsWith("right"))
                || (callback.Data.StartsWith(Name) && callback.Data.EndsWith("wrong")));
        }

        public override Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client)
        {
            var repo = Depends.Provider.GetService<Repository>();

            var user = repo.GetUserById(callback.From.Id);
            user.PreviousCommand = "to";

            var questions = repo.GetQuestionsByLang(user.Language);

            var rnd = new Random();
            int id = rnd.Next(0, questions.Count - 1);

            var answ = GenRandomAnsw(id, questions.Count);
            var genKeyboard = new[]{
                    InlineKeyboardButton.WithCallbackData(questions.ElementAt(id).Value,"to:"+questions.ElementAt(id).Value+":right"),
                    InlineKeyboardButton.WithCallbackData(questions.ElementAt(answ[0]).Value,"to:"+questions.ElementAt(id).Value+":wrong"),
                    InlineKeyboardButton.WithCallbackData(questions.ElementAt(answ[1]).Value,"to:"+questions.ElementAt(id).Value+":wrong")};
            Shuffle(genKeyboard);

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
               {genKeyboard,
                new []{
                        InlineKeyboardButton.WithCallbackData("« Меню","menu")}
                });

            var prefix = "";

            if (callback.Data.EndsWith("right"))
            {
                prefix = "Правильно! Другой вопрос. ";
                user.RightAnsw += 1;
            }
                
            else if (callback.Data.EndsWith("wrong"))
            {
                prefix = "Неправильно! Верный ответ: \"" + callback.Data.Split(":")[1] + "\". Другой вопрос. ";
                user.WrongAnsw += 1;
            }

            repo.UpdateUser(user);

            client.SendTextMessageAsync(chatId: callback.From.Id, text: prefix 
                + "Выберите правильный перевод для \""
                + questions.ElementAt(id).Key + "\":", 
                replyMarkup: inlineKeyboard);
            
            return Task.CompletedTask;
        }

        public List<int> GenRandomAnsw(int id, int max)
        {
            var list = new List<int>();

            while (list.Count != 2)
            {
                var rnd = new Random();
                int value = rnd.Next(0, max - 1);
                if (id != value)
                {
                    if (list.Count != 0)
                    {
                        if (list[0] != value)
                            list.Add(value);
                    }

                    else list.Add(value);
                }
            }

            return list;
        }

        static void Shuffle<T>(T[] a)
        {
            Random rand = new Random();
            for (int i = a.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                T tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
            }
        }
    }
}
