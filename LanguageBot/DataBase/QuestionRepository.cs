using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace LanguageBot.DataBase.Repositories
{
    class QuestionRepository: BaseRepository
    {
        DBPGSQLUtils db;
        public QuestionRepository()
        {
            db = Depends.Provider.GetService<DBPGSQLUtils>();
        }
        public void Add(Question quest)
        {
            var dbQuest = db.Questions.FirstOrDefault(x => x.Russian == quest.Russian);
            if (dbQuest == null)
            {
                db.Questions.Add(quest);
                db.SaveChanges();
            }
        }

        public Dictionary<string, string> Get(string lang)
        {
            var result = db.Questions.Where(x => x.Lang == lang).Select(x => x);
            var dict = new Dictionary<string, string>();
            foreach (var r in result)
                dict.Add(r.Russian, r.Foreign);

            return dict;
        }

        public void Update(Question quest)
        {
            db.Questions.Update(quest);
            db.SaveChanges();
        }
    }
}
