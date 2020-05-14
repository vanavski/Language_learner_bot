using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LanguageBot.DataBase
{
    public class Repository
    {
        DBPGSQLUtils db;
        public Repository()
        {
            db = Depends.Provider.GetService<DBPGSQLUtils>();
        }
        public void AddUser(User user) 
        {
            var dbUser = db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (dbUser == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User GetUserById(long userId) 
        {
            return db.Users.FirstOrDefault(x=>x.Id==userId);
        }

        public void UpdateUser(User user) 
        {
            db.Users.Update(user);
            db.SaveChanges();
        }

        public void AddQuestion(Question quest)
        {
            var dbQuest = db.Questions.FirstOrDefault(x => x.Russian == quest.Russian);
            if (dbQuest == null)
            {
                db.Questions.Add(quest);
                db.SaveChanges();
            }
        }

        public Dictionary<string, string> GetQuestionsByLang(string lang)
        {
            var result = db.Questions.Where(x => x.Lang == lang).Select(x => x);
            var dict = new Dictionary<string, string>();
            foreach (var r in result)
                dict.Add(r.Russian, r.Foreign);

            return dict;
        }

        public void UpdateQuest(Question quest)
        {
            db.Questions.Update(quest);
            db.SaveChanges();
        }
    }
}
