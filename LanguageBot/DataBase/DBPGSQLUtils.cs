using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.DataBase
{
    public class DBPGSQLUtils : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DBPGSQLUtils(DbContextOptions<DBPGSQLUtils> options) : base(options)
        {
            Database.EnsureCreated();
        }

        internal static NpgsqlConnection GetDBConnection(string herokuConnectionString)
        {
            throw new NotImplementedException();
        }
    }
}
