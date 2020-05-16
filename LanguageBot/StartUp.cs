using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LanguageBot.DataBase.Repositories;

namespace LanguageBot
{
    public static class StartUp
    {
        public static void Start() 
        {
            var service = Depends.Service;
            var cnsstr = DBUtils.ConnectionStr;
            service.AddDbContext<DBPGSQLUtils>(op => op.UseInMemoryDatabase(DBUtils.ConnectionStr));
            service.AddTransient<UsersRepository>();
            service.AddTransient<QuestionRepository>();
            service.AddTransient<StatisticsRepository>();
            Depends.Provider = Depends.Service.BuildServiceProvider();
            AddQuestions();
        }

        private static void AddQuestions()
        {
            var db = Depends.Provider.GetService<QuestionRepository>();
            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Apple",
                Russian = "Яблоко"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Orange",
                Russian = "Апельсин"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Banana",
                Russian = "Банан"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Avocado",
                Russian = "Авокадо"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Watermelon",
                Russian = "Арбуз"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Man",
                Russian = "Мужчина"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Woman",
                Russian = "Женщина"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Name",
                Russian = "Имя"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Face",
                Russian = "Лицо"
            });

            db.Add(new Question()
            {
                Lang = "Eng",
                Foreign = "Day",
                Russian = "День"
            });
        }
    }
}
