using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Database
{
    class DBPGSQLUtils
    {

        public static NpgsqlConnection
                 GetDBConnection(string connString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            return conn;
        }

    }
}
