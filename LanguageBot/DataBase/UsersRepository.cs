using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LanguageBot.DataBase.Repositories
{
    public class UsersRepository: BaseRepository
    {
        DBPGSQLUtils db;
        public UsersRepository()
        {
            db = Depends.Provider.GetService<DBPGSQLUtils>();
        }
        public void Add(User user) 
        {
            var dbUser = db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (dbUser == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User Get(long userId) 
        {
            return db.Users.FirstOrDefault(x=>x.Id==userId);
        }

        public void Update(User user) 
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
    }
}
