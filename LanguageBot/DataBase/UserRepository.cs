using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LanguageBot.DataBase
{
    public class UserRepository
    {
        DBPGSQLUtils db;
        public UserRepository()
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
    }
}
