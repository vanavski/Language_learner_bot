using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Linq;
using LanguageBot.Entity;

namespace LanguageBot.DataBase.Repositories
{
    class StatisticsRepository : BaseRepository
    {
        DBPGSQLUtils db;
        public StatisticsRepository()
        {
            db = Depends.Provider.GetService<DBPGSQLUtils>();
        }
        public void Add(Result  res)
        {
            var dbQuest = db.Results.FirstOrDefault(x => x.UserId == res.UserId && x.Date == res.Date);
            if (dbQuest == null)
            {
                db.Results.Add(res);
                db.SaveChanges();
            }
        }

        public Tuple<int, int> Get(string period, long? id)
        {
            var result = new List<Result>();
            int ra = 0;
            int wa = 0;

            switch (period)
            {
                case "day":
                    result = db.Results.Where(x => ((DateTime.Now - x.Date).TotalHours <= 24) && x.UserId == id).ToList();
                    break;
                case "week":
                    result = db.Results.Where(x => (DateTime.Now - x.Date).TotalDays <= 7 && x.UserId == id).Select(x => x).ToList();
                    break;
                case "month":
                    result = db.Results.Where(x => (DateTime.Now.Month - x.Date.Month) <= 1 && x.UserId == id).Select(x => x).ToList();
                    break;
                case "all":
                    result = db.Results.Where(x => (DateTime.Now.Year - x.Date.Year) <= 1 && x.UserId == id).Select(x => x).ToList();
                    break;
            }

            foreach (var r in result)
            {
                ra += r.RightAnsw;
                wa += r.WrongAnsw;
            }

            return new Tuple<int, int>(ra, wa);
        }

        public void Update(Result res)
        {
            db.Results.Update(res);
            db.SaveChanges();
        }
    }
}
