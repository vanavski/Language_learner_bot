using LanguageBot.DataBase.Repositories;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace LanguageBot.DataBase
{
    class TopicsRepository : BaseRepository
    {
        public TopicsRepository()
        {
            db = Depends.Provider.GetService<DBPGSQLUtils>();
        }

        DBPGSQLUtils db;

        public Dictionary<string, string> Get(string lang)
        {
            var result = db.Topics.Where(x => x.Lang == lang).Select(x => x);
            var dict = new Dictionary<string, string>();
            foreach (var r in result)
                dict.Add(r.Name, r.Link);

            return dict;
        }

    }
}
